# Introduction 
CSCE 590 Final Project - Spring 2024

In partnership with professors @ Capgemini, we built a Programming Certificate organizer.

Our project allows users to upload their certificates, track their status, and keep an eye on soon-to-expire certs.
It also allows system administrators to view all co-worker certificates, and confirm that their professionals are up to date.

# Team Members
- Ali Firooz
- Burt Sumner
- David Eta
- Nishwa Tuniki
- Patrick Burroughs
- Supriya Nayanala

# Getting Started
To get started:
- 1 Terminal:
 - cd into the frontend api folder: "consceafrontend"
 - `npm install`

# Build and Test
To Build the Project:

- 2 terminals
 - Terminal 1:
 - cd into the backend api folder: "Conscea-Api"
 - `dotnet run`

 - Terminal 2:
 - cd into the frontend api folder: "consceafrontend"
`npm start`

TODO: Describe how to run the tests. 


# DB Design

**Notes:**
- For the sake of simplicity, all `string` types translate to `VARCHAR(100)` in SQL.

- All attributes with no examples, have the same name in the Excel files and thus will take the same values.
 
- If attribute `certInfo.validFor` was defined, it overrides the user defined attribute `certArchive.expireDate` and sets it to `certArchive.certifiedDate + certInfo.validFor`. Otherwise the user have the option to set their own `certArchive.expireDate` or not.

- TODO: can we use generated GUID instead of `user.userID`?


```mermaid
erDiagram
    user {
        int             userID PK, FK
        string          firstName
        string          lastName
        string          email UK
        char(10)        phone UK
        char(1)         grade
        string          role
        string          username UK
        varbinary(32)   password
    }
    certInfo {
        string      certID PK, FK "eg: AZ-900"
        string      name UK "eg: MS. Azure AI Fundamentals"
        string      level
        string      category
        string      validFor "validity Duration; formate: yy-mm-dd"
    }
    certArchive {
        user        userID PK, FK
        certInfo    certID PK, FK
        date        certifiedDate PK
        date        expireDate
    }
    
    user     }o--|| certArchive : Have
    certInfo }o--|| certArchive : "Relate To"
```
