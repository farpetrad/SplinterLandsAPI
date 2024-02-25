# SplinterlandsAPI Test project

This project makes use of the .net secrets manager in order to protect the login and key of the user used to validate tests that require a login.
To setup the secrets manager first run `dotnet user-secrets init` from the project directory.

Next add two secrets, one for the user `HIVEUSERNAME` and one for your private posting key `KEY`.

`dotnet user-secrets set "HIVEUSERNAME" "YOUR_USER_NAME_HERE"`
`dotnet user-secrets set "KEY" "YOUR_PRIVATE_POSTING_KEY_HERE"`

See more info at https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows
