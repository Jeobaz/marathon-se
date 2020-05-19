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

# Pages links

Access to the page is shared by component `AuthorizeView`


The application has several roles:

`R` = for runner,

`C`  = for coordinator,

`A` = for administrator;

To access all pages from the columns except the first, you need to log in from an account of a certain class

**Warning:**  Pages with &#42; are displayed correctly only when going to it from another page


|Without login|Runner|Coordinator|Administrator|
| ------------ | ------------ | ------------ | ------------ |
| [1.Main Screen](https://marathon-se.azurewebsites.net/)  | [4. Runner registration](https://marathon-se.azurewebsites.net/register) |  [19.Coordinator menu](https://marathon-se.azurewebsites.net/coordinatormenu) |  [20. Administrator menu](https://marathon-se.azurewebsites.net/adminmenu) |
|  [2. Check runner](https://marathon-se.azurewebsites.net/checkrunner)   | [5. Register for an event &#42;](https://marathon-se.azurewebsites.net/registerforevent)  |  [21. Sposnorship](https://marathon-se.azurewebsites.net/sponsorshipoverview) |  [26. Manage charities &#42;](https://marathon-se.azurewebsites.net/managecharities) |
| [3. Login screen](https://marathon-se.azurewebsites.net/loginscreen)  | [8. Register сonfirmation &#42;](https://marathon-se.azurewebsites.net/registerconfirmation)  | [21. Runner management](https://marathon-se.azurewebsites.net/runnermanagement)  |  [27. Add/edit a charity &#42;](https://marathon-se.azurewebsites.net/addcharity) |
| [6. Sponsor a runner](https://marathon-se.azurewebsites.net/sponsorrunner)   | [9. Runner menu](https://marathon-se.azurewebsites.net/runnermenu)  | [23. Manage a runner &#42;](https://marathon-se.azurewebsites.net/managerunner)  | [28. Volunteer management](https://marathon-se.azurewebsites.net/volunteermanagement)  |
| [7. Sponsorship confirmation](https://marathon-se.azurewebsites.net/sponsorconfirmation/)  |   [16. Edit profile](https://marathon-se.azurewebsites.net/editrunnerprofile) | [24. Edit runner profile &#42;](https://marathon-se.azurewebsites.net/editrunnerprofile)  | [29. Import volunteers](https://marathon-se.azurewebsites.net/importvolunteers)  |
|  [10. Find out more](https://marathon-se.azurewebsites.net/findoutmore)  | [17. My results](https://marathon-se.azurewebsites.net/myraceresults)   |  [25. Certificate preview &#42;](https://marathon-se.azurewebsites.net/certificatepreview/)  | [30. User management](https://marathon-se.azurewebsites.net/usermanagment)  |
| [11. About MS 2015](https://marathon-se.azurewebsites.net/aboutmarathonskills)  | [18. My sponsorship](https://marathon-se.azurewebsites.net/mysponsorship)   |   | [31. Edit a user &#42;](https://marathon-se.azurewebsites.net/edituser/)  |
| [12. Interactive map](https://marathon-se.azurewebsites.net/interactivemap)  |   |   |  [32. Add a user &#42;](https://marathon-se.azurewebsites.net/adduser) |
| [13. List of charities](https://marathon-se.azurewebsites.net/listofcharities)  |
|  [14. Previous results](https://marathon-se.azurewebsites.net/previousraceresults) |
| [15. How long?](https://marathon-se.azurewebsites.net/howlongisamarathon)  |
| [33. BMI Calculator](https://marathon-se.azurewebsites.net/bmicalculator)  |
| [34. BMR Calculator](https://marathon-se.azurewebsites.net/bmrcalculator)  |
