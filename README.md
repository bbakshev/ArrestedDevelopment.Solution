# _Arrested Development Quotes_

#### By: Brishna Bakshev, Kai Clausen, Mike Donovan

#### _This web application uses an Arrested Development API that lists all available quotes by different characters of a hit sitcom show Arrested Development_

### <u>Table of Contents</u>
* <a href="#Description">Description</a>
* <a href="#Technologies-Used">Technologies Used</a>
* <a href="#Setup/Installation-Requirements">Setup/Installation Requirements</a>
* <a href="#Example-Query">Example Query and JSON Response</a>
* <a href="#API-Endpoints">API Endpoints</a>
* <a href="#Path-Parameters">Path Parameters</a>
* <a href="#Versions">Versions</a>
* <a href="#Known-Bugs">Known Bugs</a>
* <a href="#License">License</a>

## Description

_Arrested Development API is an API that when requested to GET all quotes by each character of the show, will return a response containing all quotes. Arrested Development API is seeded with over 400 quotes by each of the show's characters in the database. The user can click Next button and Prev button to view different quotes being call from the API._

## Technologies Used

* _C#_
* _.Net 6_
* _ASP.NET Core Web API_
* _Visual Studio Code 2019_
* _MySql_
* _MySql Workbench_
* _Entity Framework Core 6_
* _Pomelo Entity Framework Core 6 MySql_
* _ASP.NET Core Identity_
* _(Optional) Postman_

## Setup/Installation Requirements

* _Install .Net 6 SDK:_
* [OS X and Windows Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net)
* _Setup MySql Workbench:_
* [OS X and Windows Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)
* _Clone this repo to a local directory_
* _Navigate to the local directory (YourPath/ArrestedDevelopment.Solution/ArrestedDevelopmentClient) and create a new file "appsettings.json" 
* _Open this file with Visual Studio Code 2019 and add:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

* _Using Terminal on OS X or PowerShell on Windows navigate to the directory of the [ArrestedDevelopmentApi](https://github.com/bbakshev/ArrestedDevelopmentApi) repo, then the ArrestedDevelopmentApi folder (YourPath/ArrestedDevelopmentApi) and run the terminal commands (without the '$'):_ 
* _$ dotnet ef database update_
* _Making sure you've followed the MySqlWorkbench installation instructions, open MySql Workbench and select the Local 3306 server_
* _Confirm the database [YOUR-DB-NAME] that you named was successfully created by clicking on the "Schemas" tab and seeing the schema listed._ 
* _Then run the program with command :_
* _$ dotnet watch run_
* _This will autolaunch Swagger in your browser_
* _Test any API endpoints in Swagger, POSTMAN, or your own app_

## API Endpoint Guide and Example
```
GET http://localhost:5000/api/quotes/
```
* _Returns all quotes in the database_

Postman Example:  
Start a new GET request in Postman and enter the above URL. Click Send. You should see a JSON response with all quotes in the database.  

Example Return Response:
```
[
  {
    "quoteId": 2,
    "speaker": "Buster",
    "text": "What do you expect, Mother? I'm half machine!"
  },
  {
    "quoteId": 3,
    "speaker": "Buster",
    "text": "I'm a monster!"
  }
]
```

```
GET http://localhost:5000/api/quotes/{id}
```
* _Returns a quote with the matching quoteId_
* _Replace {id} with the quoteId you would like to GET_
* _Tip: You can find all quoteId's from requesting GET http://localhost:5000/api/quotes/ end point_

Postman Example:  
Start a new GET request in Postman and enter the above URL. Click Send. You should see a JSON response with the quote that matches the quoteId you entered.  
Example Return Response for quoteId equals 7:
```
{
    "quoteId": 7,
    "speaker": "Unknown",
    "text": "You could charm the black off a telegram boy"
}
```
```
POST http://localhost:5000/api/quotes/
```
* _Creates a new quote in the database_

Postman Example:  
Start a new POST request in Postman and enter the above URL. A POST request must have a request body when sending. 
To create a request body, click the Body tab located under where you entered the url, and select raw. In the dropdown menu to the right change Text to JSON.
Enter a JSON request body replacing "string" with the value you would like to enter.  
Example Request Body:
```
{
    "quoteId": 0,
    "speaker": "string",
    "text": "string"
}
```
Click Send. You should see a JSON response with the quote that you entered.

```
PUT http://localhost:5000/api/quotes/{id}
```
* _Updates a quote in the database_

Postman Example:  
Start a new PUT request in Postman and enter the above URL. A PUT request must have a request body when sending.
To create a request body, click the Body tab located under where you entered the url, and select raw. In the dropdown menu to the right change Text to JSON.
Enter a JSON request body replacing "string" with the values you would like to enter and 0 with the quoteId you would like to update. Note: You must enter an quoteId in the request body, and the entire body's values must still be assigned with either new or old values.  
Example Request Body:
```
{
  "quoteId": 0,
  "speaker": "string",
  "text": "string"
}
```
Click Send. You should see a JSON response with the quote that you updated.

```
DELETE http://localhost:5000/api/quotes/{id}
```
* _Deletes a quote in the database_

Postman Example:  
Start a new DELETE request in Postman and enter the above URL. Click Send. You should see a return status of 204 No Content.  
Confirm the quote was deleted by requesting GET http://localhost:5000/api/quotes/{id} and seeing a return status of 404 Not Found.


## Optional Path Parameters When Using Get All Quotes Endpoint
| Parameter | Type | Required | Description |
| :---: | :---: | :---: | --- |
| Speaker | String | Not Required | Returns the character that match the quote |
| Question | String | Not Required | Returns the quote that end with a question |

## Example Query
```
https://localhost:5001/api/quotes?question=true
```

## Example Returned JSON Response
```
{
    "quoteId": 8,
    "speaker": "Unknown",
    "text": "Did you see the new Poof?"
}
```

## Futher Exploration: Pagination
* _Paging refers to getting partial results from an API._ 
* _Change the pagesize to your desired number in the URL: https://localhost:5001/api/Quotes?maxWords=4&speaker=GOB&question=false&page=1&pageSize=4_

## Known Bugs

N/A

## License
Enjoy the site! If you have questions or suggestions for fixing the code, please contact me!

[MIT](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt)

Copyright (c) 2023 Brishna Bakshev, Kai Clausen, Mike Donovan