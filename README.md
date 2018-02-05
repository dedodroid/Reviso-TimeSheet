# Reviso TimeSheet
  
  Reviso TimeSheet is a SPA designed for freelancers. 
  Its goal is to keep note of work hours spent on several projects by several customers and to make invoices.

# Components:

  Back-end:
  - Language: C# Asp .Net 
  - Web framework: Asp .Net Web API 
  - ORM: Entity Framework as ORM
  - Application Framework: Abp (Asp .Net Boilerplate)
  - DataBase: SqlLocalDb

  Front-end:
  - SPA framework: Angularjs
  - HTML/CSS framework: Bootstrap

# Features:

  - Add, edit and remove customers, projects and timesheet
  - Order and filter data and automatic recalc of the hours
  - Persist data to database

# TODO:

  - Create invoices
  - Validations of input fields
  - Confirmation messages, for instance when delete records
  - Move Entity Framework code to an own project (now it is in Repository project)

# How to use:

  - Install at least SqlLocaLDB:
    https://www.microsoft.com/en-us/download/details.aspx?id=29062
  - If you install another version of Sql Server you must change the connection string on the web.config of the WebApi project
  - Set "multiple startup projects" in Visual Studio solution:
    select  “.UI.Web” and “.WebApi” to run
  - Start solution and Visul studio should be automatically restore nuget packages and everything should be fine
