# TodoListing
Simple Todo API

Todo API using .Net Core 2 / Entity Framework

This API uses custom Authentification Scheme using "ApiKey" header provided in request.
ApiKey is compared towards hardcoded values in appsettings.config.
All api keys can be found under "ApiKeys" section of appsettings.config.

Entity Framework is used for CRUD .

Update Connection String "TodoListingDbContext" in appsettings.config to use any SQL Database.

Then Run "update-database" from package-manager console to create dataBase.


