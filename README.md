# DomnerTech.IdentityService
Singal Sign On Service

## DB Migration

### Update dotnet-ef

```bash
dotnet tool update --global dotnet-ef
```

### Initial Migration

```bash
dotnet ef migrations add InitialCreate \
-p src/DomnerTech.IdentityService.Infrastructure \
-s src/DomnerTech.IdentityService.Api
```

### Apply Migration

```bash
dotnet ef database update \
-p src/DomnerTech.IdentityService.Infrastructure \
-s src/DomnerTech.IdentityService.Api
```