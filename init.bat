mkdir src
cd src
dotnet new classlib -o App.Contracts -n App.Contracts
dotnet new webapi -o App.WebApi -n App.WebApi
dotnet new mstest -o App.WebApi.Tests -n App.WebApi.Tests
dotnet new sln -n App
dotnet sln add App.WebApi/App.WebApi.csproj
dotnet sln add App.WebApi.Tests/App.WebApi.Tests.csproj
dotnet sln add App.Contracts/App.Contracts.csproj
cd App.WebApi.Tests
dotnet add package Microsoft.AspNetCore.TestHost
cd..
