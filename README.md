# Marathon-SE
Marathon-SE

# Stack technologies
* Blazor
* MS SQL Server
* Entity Framework Core
* ASP .NET Core 3.1

# Installation
For successful installation, you must complete a number of steps:
1. Set connection string in `Backend/appsettings.json` and `ImportStaffData/ImportStaffData/App.config`
2. To perform the migration in PM for project `Backend`:
```bash
PM> Update-Database
```
3. Import SQL data from folder `SQL`
4. You must import data for the task for project `ImportStaffData`. To do this, you just need to launch the project.

Complete! Launch Backend and Frontend projects.

# Demo
[marathon-se.azurewebsites.net](https://marathon-se.azurewebsites.net/)
