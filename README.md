[![C#](https://img.shields.io/badge/C%23-2ea44f)](https://github.com/dotnet/csharplang)
[![.NET - 6](https://img.shields.io/badge/.NET-6-2ea44f)](https://dotnet.microsoft.com/en-us/)
[![Blazor - Server](https://img.shields.io/badge/Blazor-Server-2ea44f)](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
[![Bootstrap - 5](https://img.shields.io/badge/Bootstrap-5-2ea44f)](https://)
[![License](https://img.shields.io/badge/License-MIT-blue)](#license)

# Documents-Database

GUI for doing basic CRUD operations on documents in the database

## Description

GUI is made for storing and searching for documents(mostly bills for now). The idea was to simplify storing bills so they could be in one place and easily found if needed. Documents are stored in a database in binary format and read when needed. Every document has company name and items(items on the bill so they can be searched too), tags(another optional thing for easier search).

### Installing
- Create a database using [SQLscript.sql](SQLscript.sql)
- Change SQL connection string in appsettings.json

### To do

- [ ] Add categories for documents so more types of documents can be easier to store
- [ ] Add user authentications
- [x] Improve search filter
