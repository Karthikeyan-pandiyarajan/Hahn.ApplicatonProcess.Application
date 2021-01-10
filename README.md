# applicant-registration-api

This application has been developed in .Net 5.0 in Visual Studio 2019 and hosted through Kestrel host with the reference of the below url.
http://www.codedigest.com/quick-start/5/learn-kestrel-webserver-in-10-minutes

This applicant-registration-api has CRUD operations with Entity-framework in-memory database with following actions: 

GET
POST
PUT
DELETE

## Run app

Clone this application to your local machine or download the ZIP file and extract the files.

Double click the .sln file in the folders or open this solution with Visual Studio 2019.

Clean the solution and Build the solution to restore the nuget packages.

Run or Debug the application with project name "Hahn.ApplicatonProcess.Application".

Finally, the application will be running the Kestrel host and swagger UI will be appeared.

TO Check POST or PUT api use the following JSON

{
  "data": {
    "name": "string",
    "familyName": "string",
    "address": "string",
    "countryOfOrigin": "string",
    "emailAddress": "string",
    "age": 0,
    "hired": true,
    "dob": "string"
  }
}
