### Adding necessary dependencies to the project

### We need to add some libraries to the project, including EF Core for talking with the database. I added the following to project.json's dependencies section:


    <PackageReference Include="Microsoft.AspNetCore.Identity" Version="2.2.0" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.2" />
    <PackageReference Include="Microsoft.AspNetCore.SpaServices.Extensions" Version="3.1.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.2">