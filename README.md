# Minimal API Reference Application

Use PostgreSQL, EF Core, & .NET 8's new Identity scaffolding. To run the app, do the following.

Run
```console
   docker compose up --detach
   dotnet ef database update --context IdentityDbContext
   dotnet run
```

Use the Swagger endpoints to register an account an login. Copy the access token to the Authorization input field.

~~~~You can also import the supplied Postman collection and run the workflow.