Write-Host "Adding project references" -ForegroundColor Green
dotnet sln add .\Core\Common\src\Adesso.Dapr.Core.Common.Abstraction\Adesso.Dapr.Core.Common.Abstraction.csproj
dotnet sln add .\Core\Api\src\Adesso.Dapr.Core.Api.Abstraction\Adesso.Dapr.Core.Api.Abstraction.csproj 

dotnet sln add .\Core\CQRS\src\Adesso.Dapr.Core.CQRS.Abstraction\Adesso.Dapr.Core.CQRS.Abstraction.csproj
dotnet sln add .\Core\CQRS\src\Adesso.Dapr.Core.CQRS\Adesso.Dapr.Core.CQRS.csproj 

dotnet sln add .\Core\Domain\src\Adesso.Dapr.Core.Domain.Abstraction\Adesso.Dapr.Core.Domain.Abstraction.csproj
dotnet sln add .\Core\Domain\src\Adesso.Dapr.Core.Domain\Adesso.Dapr.Core.Domain.csproj

dotnet sln add .\Core\EFCore\src\Adesso.Dapr.Core.EFCore.Abstraction\Adesso.Dapr.Core.EFCore.Abstraction.csproj
dotnet sln add .\Core\EFCore\src\Adesso.Dapr.Core.EFCore\Adesso.Dapr.Core.EFCore.csproj 

dotnet sln add .\Core\IOC\src\Adesso.Dapr.Core.IOC.Abstraction\Adesso.Dapr.Core.IOC.Abstraction.csproj
dotnet sln add .\Core\IOC\src\Adesso.Dapr.Core.IOC\Adesso.Dapr.Core.IOC.csproj 

dotnet sln add .\Core\Starter\src\Adesso.Dapr.Core.Starter.Abstraction\Adesso.Dapr.Core.Starter.Abstraction.csproj
dotnet sln add .\Core\Starter\src\Adesso.Dapr.Core.Starter\Adesso.Dapr.Core.Starter.csproj 
dotnet sln add .\Core\Starter\src\Adesso.Dapr.Core.Starter.Api\Adesso.Dapr.Core.Starter.Api.csproj 

dotnet sln add .\Core\UnitOfWork\src\Adesso.Dapr.Core.UnitOfWork.Abstraction\Adesso.Dapr.Core.UnitOfWork.Abstraction.csproj
dotnet sln add .\Core\UnitOfWork\src\Adesso.Dapr.Core.UnitOfWork\Adesso.Dapr.Core.UnitOfWork.csproj 

dotnet sln add .\Core\Validation\src\Adesso.Dapr.Core.Validation.Abstraction\Adesso.Dapr.Core.Validation.Abstraction.csproj
dotnet sln add .\Core\Validation\src\Adesso.Dapr.Core.Validation\Adesso.Dapr.Core.Validation.csproj 



Write-Host "Adding Catalog project and  references" -ForegroundColor Green

dotnet new classlib -n Adesso.Dapr.MicroServices.Catalog.Abstraction
dotnet new classlib -n Adesso.Dapr.MicroServices.Catalog.Application
dotnet new classlib -n Adesso.Dapr.MicroServices.Catalog.Core
dotnet new classlib -n Adesso.Dapr.MicroServices.Catalog.Domain
dotnet new classlib -n Adesso.Dapr.MicroServices.Catalog.Repository
dotnet new webapi -n Adesso.Dapr.MicroServices.Catalog.Api


dotnet sln add .\PubSub\src\Adesso.Dapr.PubSub\Adesso.Dapr.PubSub.csproj
dotnet sln add .\Cryptography\src\Adesso.Dapr.Crypt\Adesso.Dapr.Crypt.csproj

 dotnet sln add .\MicroServices\src\Services\Catalog\src\Adesso.Dapr.MicroServices.Catalog.Api\Adesso.Dapr.MicroServices.Catalog.Api.csproj
 dotnet sln add .\MicroServices\src\Services\Catalog\src\Adesso.Dapr.MicroServices.Catalog.Application\Adesso.Dapr.MicroServices.Catalog.Application.csproj
 dotnet sln add .\MicroServices\src\Services\Catalog\src\Adesso.Dapr.MicroServices.Catalog.Core\Adesso.Dapr.MicroServices.Catalog.Core.csproj
 dotnet sln add .\MicroServices\src\Services\Catalog\src\Adesso.Dapr.MicroServices.Catalog.Domain\Adesso.Dapr.MicroServices.Catalog.Domain.csproj
 dotnet sln add .\MicroServices\src\Services\Catalog\src\Adesso.Dapr.MicroServices.Catalog.Repository\Adesso.Dapr.MicroServices.Catalog.Repository.csproj
