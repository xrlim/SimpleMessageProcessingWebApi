# SimpleMessageProcessingWebApi


## Stack 
| Layer       | Stack |
| ----------- | ----------- |
| UI      | N.A.       |
| Api   | ASP.NET Core 6        |
| ORM   | Entity Framework Core 6        |
| Database   | SQLite        |


## How to run the program.
1) Open up your prefer terminal 
2) From terminal, traverse to path *src\SimpleMessageProcessing.Api*
3) Run command *dotnet ef database update*
<br/>Notes: Please install or update dotnet ef cli, refers to *https://docs.microsoft.com/en-us/ef/core/cli/dotnet*<br/>
5) Run the *SimpleMessageProcessing.Client* and *SimpleMessageProcessing.Api* project. 
6) If api can't be called, check CORS settings in *appsetting.Development.json* file for *CorsPaths* section.
 <br/>To ensure the url is being allowed by CORS.<br/>
