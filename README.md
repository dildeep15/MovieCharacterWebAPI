# MovieCharacterWebAPI
This is an ASP.NET Core web API that uses Entity Framework with code first approach. There are three models in this project(Character, Movies & Franchise).
These three models have following relationship :
- Many to Many relationship between Characters & Movies.
- One to Many realtionship between Franchise & Movies.
  ![DatabaseDiagram](https://github.com/dildeep15/MovieCharacterWebAPI/assets/29199655/06556fd9-4e88-42b6-9993-0e464c957d54)


## User can do following operations:
- Basic CRUD for:
    - Movies
    - Characters
    - Franchises
- Get all movies in franchise
- Get all characters in movie
- Get all characters in franchise
- Update characters in a movie
- Update movies in a franchise

## Requirement & Installation
### Make sure you have installed atleast the following tools:
- Visual Studio 2019 with .NET 5
- SQL Server Management Studio

To clone the project run in console:
```
git clone https://github.com/dildeep15/MovieCharacterWebAPI.git

```
 - Open solution in visual studio
 - Edit connection string inside appsettings.json to include your SQL server name
 ```
 "DefaultConnection": "Data Source=LAPTOP-9CG2BN0V\\SQLEXPRESS;Initial Catalog=MovieCharacterDB;Integrated Security=True;"
 ```
 - Open Package Manager Console and run the following command:
 ```
 Update-Database
 ```

## Usage
After installation steps, you can run the application and use swagger to test endpoints

## Contributors
- Dildeep Singh https://github.com/dildeep15
  
## License
[MIT](https://choosealisence.com/licenses/mit/)
