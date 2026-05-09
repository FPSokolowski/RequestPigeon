using Microsoft.EntityFrameworkCore;
using RequestPigeon.Domain.Common;
using RequestPigeon.Domain.Entities;

namespace RequestPigeon.Infrastructure.Persistence;

public sealed class RequestPigeonDbContext(DbContextOptions<RequestPigeonDbContext> options) : DbContext(options)
{
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<AuthenticationSettings> AuthenticationSettings => Set<AuthenticationSettings>();
    public DbSet<Claim> Claims => Set<Claim>();
    public DbSet<DemoReseedLog> DemoReseedLogs => Set<DemoReseedLog>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<LeaveRequestDocument> LeaveRequestDocuments => Set<LeaveRequestDocument>();
    public DbSet<PurchaseRequestDocument> PurchaseRequestDocuments => Set<PurchaseRequestDocument>();
    public DbSet<BusinessTripRequestDocument> BusinessTripRequestDocuments => Set<BusinessTripRequestDocument>();
    public DbSet<CredentialsRequestDocument> CredentialsRequestDocuments => Set<CredentialsRequestDocument>();
    public DbSet<RefundRequestDocument> RefundRequestDocuments => Set<RefundRequestDocument>();
    public DbSet<OtherRequestDocument> OtherRequestDocuments => Set<OtherRequestDocument>();
    public DbSet<DocumentApprovalRule> DocumentApprovalRules => Set<DocumentApprovalRule>();
    public DbSet<DocumentApprovalStep> DocumentApprovalSteps => Set<DocumentApprovalStep>();
    public DbSet<DocumentSettings> DocumentSettings => Set<DocumentSettings>();
    public DbSet<LogApp> LogApps => Set<LogApp>();
    public DbSet<LogDocument> LogDocuments => Set<LogDocument>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RoleClaim> RoleClaims => Set<RoleClaim>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserClaim> UserClaims => Set<UserClaim>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Enum>().HaveConversion<string>();
        configurationBuilder.Properties<decimal>().HavePrecision(9, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureCommon(modelBuilder);
        ConfigureUsersAndAuthorization(modelBuilder);
        ConfigureDocuments(modelBuilder);
        ConfigureDocumentSettings(modelBuilder);
        ConfigureLogs(modelBuilder);
    }

    private static void ConfigureCommon(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.CreatedAt))
                    .HasColumnType("datetime2(7)");

                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.LastModification))
                    .HasColumnType("datetime2(7)");

                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.RowVersion))
                    .IsRowVersion();
            }
        }
    }

    private static void ConfigureUsersAndAuthorization(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.LockedFailedLog).HasColumnType("datetime2(0)");
            entity.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.SuperiorRole)
                .WithMany(x => x.SubordinateRoles)
                .HasForeignKey(x => x.SuperiorRoleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.ToTable("Claims");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.ValueType).HasMaxLength(16).HasConversion<string>();
        });

        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable("RoleClaims");
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Role).WithMany(x => x.RoleClaims).HasForeignKey(x => x.RoleId);
            entity.HasOne(x => x.Claim).WithMany(x => x.RoleClaims).HasForeignKey(x => x.ClaimId);
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.ToTable("UserClaims");
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.User).WithMany(x => x.UserClaims).HasForeignKey(x => x.UserId);
            entity.HasOne(x => x.Claim).WithMany(x => x.UserClaims).HasForeignKey(x => x.ClaimId);
        });

        modelBuilder.Entity<AuthenticationSettings>(entity =>
        {
            entity.ToTable("AuthenticationSettings");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.LockoutTime).HasColumnType("time");
        });
    }

    private static void ConfigureDocuments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Documents");
            entity.UseTptMappingStrategy();
            entity.HasKey(x => x.Id);
            entity.Property(x => x.DateTime).HasColumnType("datetime2(0)");
            entity.Property(x => x.Type).HasMaxLength(16).HasConversion<string>();
            entity.Property(x => x.Status).HasMaxLength(16).HasConversion<string>();
            entity.Property(x => x.Priority).HasMaxLength(16).HasConversion<string>();
            entity.HasOne(x => x.Requester)
                .WithMany(x => x.RequestedDocuments)
                .HasForeignKey(x => x.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<LeaveRequestDocument>(entity =>
        {
            entity.ToTable("LeaveRequestDocuments");
            entity.Property(x => x.Id).HasColumnName("DocumentId");
            entity.Property(x => x.LeaveType).HasMaxLength(16).HasConversion<string>();
        });

        modelBuilder.Entity<PurchaseRequestDocument>(entity =>
        {
            entity.ToTable("PurchaseRequestDocuments");
            entity.Property(x => x.Id).HasColumnName("DocumentId");
            entity.Property(x => x.ExpensesType).HasMaxLength(16).HasConversion<string>();
        });

        modelBuilder.Entity<BusinessTripRequestDocument>(entity =>
        {
            entity.ToTable("BusinessTripRequestDocuments");
            entity.Property(x => x.Id).HasColumnName("DocumentId");
            entity.Property(x => x.Purpose).HasMaxLength(16).HasConversion<string>();
        });

        modelBuilder.Entity<CredentialsRequestDocument>(entity =>
        {
            entity.ToTable("CredentialsRequestDocuments");
            entity.Property(x => x.Id).HasColumnName("DocumentId");
        });

        modelBuilder.Entity<RefundRequestDocument>(entity =>
        {
            entity.ToTable("RefundRequestDocuments");
            entity.Property(x => x.Id).HasColumnName("DocumentId");
            entity.Property(x => x.ExpensesType).HasMaxLength(16).HasConversion<string>();
        });

        modelBuilder.Entity<OtherRequestDocument>(entity =>
        {
            entity.ToTable("OtherRequestDocuments");
            entity.Property(x => x.Id).HasColumnName("DocumentId");
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.ToTable("Attachments");
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Document).WithMany(x => x.Attachments).HasForeignKey(x => x.DocumentId);
        });

        modelBuilder.Entity<DocumentApprovalStep>(entity =>
        {
            entity.ToTable("DocumentApprovalSteps");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Status).HasMaxLength(16).HasConversion<string>();
            entity.Property(x => x.Decision).HasMaxLength(16).HasConversion<string>();
            entity.Property(x => x.DateTimeIssued).HasColumnType("datetime2(0)");
            entity.Property(x => x.DateTimeDecision).HasColumnType("datetime2(0)");
            entity.HasOne(x => x.Document).WithMany(x => x.ApprovalSteps).HasForeignKey(x => x.DocumentId);
            entity.HasOne(x => x.Approver).WithMany(x => x.ApprovalSteps).HasForeignKey(x => x.ApproverId).OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureDocumentSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentSettings>(entity =>
        {
            entity.ToTable("DocumentSettings");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Type).HasMaxLength(16).HasConversion<string>();
        });

        modelBuilder.Entity<DocumentApprovalRule>(entity =>
        {
            entity.ToTable("DocumentApprovalRules");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.DecisionMakerType).HasMaxLength(32).HasConversion<string>();
            entity.HasOne(x => x.DocumentSettings).WithMany(x => x.ApprovalRules).HasForeignKey(x => x.DocumentSettingsId);
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureLogs(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogDocument>(entity =>
        {
            entity.ToTable("LogDocuments");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.EventType).HasMaxLength(32).HasConversion<string>();
            entity.Property(x => x.StatusBefore).HasMaxLength(16).HasConversion<string>();
            entity.Property(x => x.StatusAfter).HasMaxLength(16).HasConversion<string>();
            entity.HasOne(x => x.Document).WithMany(x => x.Logs).HasForeignKey(x => x.DocumentId);
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<LogApp>(entity =>
        {
            entity.ToTable("LogApps");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.LogLevel).HasMaxLength(16).HasConversion<string>();
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DemoReseedLog>(entity =>
        {
            entity.ToTable("DemoReseedLogs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.StartedAt).HasColumnType("datetime2(0)");
            entity.Property(x => x.CompletedAt).HasColumnType("datetime2(0)");
            entity.HasOne(x => x.StartedByUser).WithMany().HasForeignKey(x => x.StartedByUserId).OnDelete(DeleteBehavior.Restrict);
        });
    }
}
