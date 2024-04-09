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

- Using the `Account` name instead of `User`, to keep further changes in the backend to a minimum.

- All attributes with no examples, have the same name in the excel files and thus will take the same values.
 
- If attribute `CertInfo.expire` is set to "True", the user should receive a notification when a certificate expires and ask them to renew it (change the `CertArchive.expireDate`).

> TODO: `CertInfo.expire` **does not** contradict with `CertArchive.expireDate`? So either one expires sooner, the system should prompt the user? Or does the `CertArchive.expireDate` should be set based on the `CertInfo.expire`?


```mermaid
erDiagram
    Account {
        int             Id PK, FK
        string          firstName
        string          lastName
        string          email UK
        char(10)        phone UK
        char(1)         grade
        string          role
        string(32)      username UK
        varbinary(32)   password
        bool            isOnline

    }
    CertInfo {
        string          certId PK, FK "eg: AZ-900"
        string          name UK "eg: MS. Azure AI Fundamentals"
        string          level
        string          category
        bool            expire "certificate valid for 1 year only?"
    }
    CertArchive {
        Account         Id PK, FK
        CertInfo        certId PK, FK
        date            certifiedDate PK
        date            expireDate
    }
    
    Account  }o--|| CertArchive : Have
    CertInfo }o--|| CertArchive : "Relate To"
```
