This is the back-end solution project, implemented with Clean Architecture pattern as a software architectural design approach.
The code design is very clean, it's latest .net core 8, and it's a API, so it can be consumed by multiple users.
We have our different layers, like the Domain layer where the models are, the Application layer where the business logic is and so on.
The unit of work methods are pretty simple, and in real case scenario they should be more advanced, like using delegates for handeling operations.

There are so things that I 

## Installation

1.  Download the code - Clone the repository or download the zip file

2.  Change the connection string - In the WebAPI project in the ```appsettings.json``` file enter your server name 
    and name of the database.

3.  Go into the Package Manager Console and type: ```Add-Migration "Init```"
    <br />
    <br />
    ***!IMPORTANT - Make sure that your WebAPI is Set as Startup Project, and in the Package Manager Console your Default project is Data in Infrastructure folder.
    - this will create folder Migrations in Data class library project, with the migration. 
      
4.  When this is done, just type in the Package Manager Console: ```Update-Database```
    - this will create the database with you database name and the models.
    
5.  Run the project
