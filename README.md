hello this is an explination on how to handel the project

first of all you need to create a file named: 
appsettings.json

and put it inside the COCServer folder

then edit it and add the folowing:
and make sure to edit the folowing:
DefaultConnection*
SecretKey*

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.Hosting.Lifetime": "Information",
      "System": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "your local MongoDB Database Connection"
  },
  "JwtSettings": {
    "SecretKey": "Generate a bace HS512 secrectKey",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  },
  "DatabaseName": "COCDatabase",
  "AuthDatabaseName": "AuthDataBase",
  "AdminAcc": {
    "UserName": "adminUser",
    "Email": "admin@admin.admin",
    "Password": "Password123!@"
  },
  "AllowedOrigins": [
    "http://localhost:3000",
    "http://localhost:5173",
    "http://localhost:5174",
  ],
}

then you can simply run the project from COCServer project and it will work
