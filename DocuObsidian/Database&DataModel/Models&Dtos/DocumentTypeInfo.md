## Properties

| Name               | Type .NET        | Nullable | Description                                                                       | Notes                                  |
| ------------------ | ---------------- | :------: | :-------------------------------------------------------------------------------- | -------------------------------------- |
| Type               | [[DocumentType]] |    ❌     | Document's type                                                                   |                                        |
| Header             | string(128)      |    ❌     | Document's header                                                                 |                                        |
| TextContentDefault | string(2048)     |    ✔     | Default text (specification / explaination / reason / purpose / additional notes) | Fills TextContent for a fresh document |
