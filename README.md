# EntityFrameworkCore Demo

EntityFrameworkCore Demo in a WebAPI project.

Dependencies: .NET Core 2.1.1, Microsoft.EntityFrameworkCore v2.1.1

[Medium Blog Post](https://medium.com/@changhuixu/ientitytypeconfiguration-t-in-entityframework-core-3fe7abc5ee7a)

## Usage

1. Apply EF Migration to your local SQL Server database

    ```powershell
    # if using Package Manger Console in Visual Studio
    Update-Database
  
    # if using console
    dotnet ef database update
    ```

1. Run Web App

    In `WebBlogs.Web` folder, issue command `dotnet run`, then in browser navigate to [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html). In Swagger page, you can try out APIs.

