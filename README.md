# Minimal API Reference Application

Uses PostgreSQL, EF Core, & .NET 8's new Identity scaffolding. To run the app, do the following.

Run
```console
   docker compose up -d
   dotnet ef database update --context IdentityDbContext
   dotnet run
```

Use the Swagger endpoints to register an account an login. Copy the access token to the Authorization input field.

You can also import the supplied Postman collection and run the workflow.

# NOTES:
- This is a work in progress. Commits made on 2023.09.08 are completely untested so watch out!
- Added example code for implementing OneOf which I'm a bit enamored with.