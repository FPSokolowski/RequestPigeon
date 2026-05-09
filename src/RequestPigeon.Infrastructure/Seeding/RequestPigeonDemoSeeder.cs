using Bogus;
using Microsoft.EntityFrameworkCore;
using RequestPigeon.Domain.Entities;
using RequestPigeon.Domain.Enums;
using RequestPigeon.Infrastructure.Persistence;

namespace RequestPigeon.Infrastructure.Seeding;

public sealed class RequestPigeonDemoSeeder(RequestPigeonDbContext dbContext)
{
    public async Task SeedIfNeededAsync(CancellationToken cancellationToken = default)
    {
        if (!await dbContext.Roles.AnyAsync(cancellationToken))
        {
            await SeedAuthorizationAsync(cancellationToken);
        }

        if (!await dbContext.DocumentSettings.AnyAsync(cancellationToken))
        {
            await SeedDocumentSettingsAsync(cancellationToken);
        }

        if (!await dbContext.Users.AnyAsync(cancellationToken))
        {
            await SeedUsersAsync(cancellationToken);
        }

        if (!await dbContext.Documents.AnyAsync(cancellationToken))
        {
            await SeedDocumentsAsync(cancellationToken);
        }
    }

    private async Task SeedAuthorizationAsync(CancellationToken cancellationToken)
    {
        var claims = new[]
        {
            "SuperUser",
            "RequestPigeon_SuperUser",
            "RequestPigeon_Home",
            "RequestPigeon_Home_Index_GET",
            "RequestPigeon_Documents",
            "RequestPigeon_Documents_Index_GET",
            "RequestPigeon_Documents_Details_GET",
            "RequestPigeon_Documents_Create_GET",
            "RequestPigeon_Documents_Create_POST",
            "RequestPigeon_Documents_Submit_POST",
            "RequestPigeon_Approvals",
            "RequestPigeon_Approvals_Index_GET",
            "RequestPigeon_Approvals_Decide_POST",
            "RequestPigeon_Demo",
            "RequestPigeon_Demo_Reseed_POST"
        }
        .Select(name => new Claim
        {
            Id = Guid.NewGuid(),
            Name = name,
            ValueType = ClaimValueType.Bool,
            DefaultValue = "true"
        })
        .ToList();

        var adminRole = new Role { Id = Guid.NewGuid(), Name = "Admin" };
        var managerRole = new Role { Id = Guid.NewGuid(), Name = "Manager", SuperiorRole = adminRole };
        var employeeRole = new Role { Id = Guid.NewGuid(), Name = "Employee", SuperiorRole = managerRole };

        dbContext.Claims.AddRange(claims);
        dbContext.Roles.AddRange(adminRole, managerRole, employeeRole);

        var adminClaims = claims
            .Select(claim => new RoleClaim { Id = Guid.NewGuid(), Role = adminRole, Claim = claim });

        var managerClaimNames = claims
            .Where(claim => claim.Name.Contains("_Approvals", StringComparison.Ordinal)
                || claim.Name.Contains("_Documents", StringComparison.Ordinal)
                || claim.Name == "RequestPigeon_Home"
                || claim.Name == "RequestPigeon_Home_Index_GET")
            .Select(claim => new RoleClaim { Id = Guid.NewGuid(), Role = managerRole, Claim = claim });

        var employeeClaimNames = claims
            .Where(claim => claim.Name.Contains("_Documents", StringComparison.Ordinal)
                || claim.Name == "RequestPigeon_Home"
                || claim.Name == "RequestPigeon_Home_Index_GET")
            .Select(claim => new RoleClaim { Id = Guid.NewGuid(), Role = employeeRole, Claim = claim });

        dbContext.RoleClaims.AddRange(adminClaims);
        dbContext.RoleClaims.AddRange(managerClaimNames);
        dbContext.RoleClaims.AddRange(employeeClaimNames);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedUsersAsync(CancellationToken cancellationToken)
    {
        var roles = await dbContext.Roles.ToDictionaryAsync(x => x.Name, cancellationToken);
        var faker = new Faker("pl");

        var users = new List<User>
        {
            CreateUser("admin", "Ada", "Admin", roles["Admin"], "admin@requestpigeon.local"),
            CreateUser("manager", "Marta", "Manager", roles["Manager"], "manager@requestpigeon.local"),
            CreateUser("employee", "Emil", "Employee", roles["Employee"], "employee@requestpigeon.local")
        };

        for (var index = 1; index <= 6; index++)
        {
            var firstName = faker.Name.FirstName();
            var surname = faker.Name.LastName();
            var role = index <= 2 ? roles["Manager"] : roles["Employee"];

            users.Add(CreateUser(
                $"demo{index}",
                firstName,
                surname,
                role,
                faker.Internet.Email(firstName, surname, "requestpigeon.local")));
        }

        dbContext.Users.AddRange(users);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedDocumentSettingsAsync(CancellationToken cancellationToken)
    {
        var settings = new[]
        {
            CreateDocumentSettings(DocumentType.Leave, "Wniosek o urlop", "Proszę o zatwierdzenie urlopu."),
            CreateDocumentSettings(DocumentType.Purchase, "Wniosek o zakup", "Proszę o zatwierdzenie zakupu."),
            CreateDocumentSettings(DocumentType.Credentials, "Wniosek o przyznanie uprawnień", "Proszę o przyznanie wskazanych uprawnień."),
            CreateDocumentSettings(DocumentType.BusinessTrip, "Wniosek o wyjazd służbowy", "Proszę o zatwierdzenie wyjazdu służbowego."),
            CreateDocumentSettings(DocumentType.Refund, "Wniosek o zwrot kosztów", "Typ przygotowany po MVP."),
            CreateDocumentSettings(DocumentType.Other, "Pismo ogólne", "Typ przygotowany po MVP.")
        };

        dbContext.DocumentSettings.AddRange(settings);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedDocumentsAsync(CancellationToken cancellationToken)
    {
        var users = await dbContext.Users
            .Include(x => x.Role)
            .ToListAsync(cancellationToken);

        var employees = users.Where(x => x.Role.Name == "Employee").ToList();
        var approvers = users.Where(x => x.Role.Name is "Manager" or "Admin").ToList();
        var faker = new Faker("pl");

        var documents = new List<Document>();

        foreach (var employee in employees.Take(4))
        {
            documents.Add(new LeaveRequestDocument
            {
                Id = Guid.NewGuid(),
                RequesterId = employee.Id,
                DateTime = DateTime.UtcNow.AddDays(-faker.Random.Int(1, 14)),
                Status = DocumentStatus.InReview,
                Priority = faker.PickRandom<DocumentPriority>(),
                TextContent = faker.Lorem.Sentence(),
                DateStart = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(faker.Random.Int(7, 30))),
                DateEnd = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(faker.Random.Int(31, 45))),
                Days = faker.Random.Int(2, 10),
                LeaveType = faker.PickRandom<LeaveType>()
            });

            documents.Add(new PurchaseRequestDocument
            {
                Id = Guid.NewGuid(),
                RequesterId = employee.Id,
                DateTime = DateTime.UtcNow.AddDays(-faker.Random.Int(1, 14)),
                Status = DocumentStatus.Draft,
                Priority = faker.PickRandom<DocumentPriority>(),
                TextContent = faker.Commerce.ProductDescription(),
                PlannedPurchaseDueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(faker.Random.Int(7, 60))),
                PlannedEstimatedCost = faker.Random.Decimal(100, 5000),
                ExpensesType = faker.PickRandom<ExpensesType>()
            });
        }

        dbContext.Documents.AddRange(documents);
        await dbContext.SaveChangesAsync(cancellationToken);

        foreach (var document in documents.Where(x => x.Status == DocumentStatus.InReview))
        {
            dbContext.DocumentApprovalSteps.Add(new DocumentApprovalStep
            {
                Id = Guid.NewGuid(),
                DocumentId = document.Id,
                ApproverId = faker.PickRandom(approvers).Id,
                StepOrder = 1,
                Status = ApprovalStepStatus.Pending,
                DateTimeIssued = DateTime.UtcNow
            });

            dbContext.LogDocuments.Add(new LogDocument
            {
                Id = Guid.NewGuid(),
                DocumentId = document.Id,
                UserId = document.RequesterId,
                EventType = DocumentEventType.Sent,
                StatusAfter = document.Status,
                Info = "Seeded demo document sent to approval."
            });
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private static User CreateUser(string userName, string firstName, string surname, Role role, string email)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            UserName = userName,
            FirstName = firstName,
            Surname = surname,
            Email = email,
            IsActiveAccount = true,
            IsDemo = true,
            Password = "demo",
            Role = role,
            PassChangeRequired = false
        };
    }

    private static DocumentSettings CreateDocumentSettings(DocumentType type, string header, string defaultTextContent)
    {
        return new DocumentSettings
        {
            Id = Guid.NewGuid(),
            Type = type,
            Header = header,
            DefaultTextContent = defaultTextContent,
            ApprovalRules =
            [
                new DocumentApprovalRule
                {
                    Id = Guid.NewGuid(),
                    StepOrder = 1,
                    DecisionMakerType = DecisionMakerType.Role,
                    RoleOrClaimName = "Manager"
                }
            ]
        };
    }
}
