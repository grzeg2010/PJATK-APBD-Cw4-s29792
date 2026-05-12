Connection string
> Data Source=(localdb)\apbd;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

```
dotnet tool install --global dotnet-ef
```

NuGet
- Swashbuckle.AspNetCore.SwaggerUI
- microsoft.entityframeworkcore.sqlserver
- Microsoft.EntityFrameworkCore.Design

```
dotnet ef migrations add nameOfMigration
dotnet ef migrations remove
dotnet ef database update
```