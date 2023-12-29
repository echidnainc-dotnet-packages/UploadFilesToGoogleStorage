# UploadFileToGoogleStorage
Sample .NET Console Executable to Upload files to Google storage bucket
 
## File and Directories
```bash
├── README.md
├── EventDataExport
│   └──bin
│   │  └── Debug files
│   │  └── Rlease files
│   │─── Client Screat json file 
│───└Properties 
│   │└─ AssemblyInfo.cs
│   └── App.config
│   └── client_screat google json key
│   └── ExecutionTimeLogger.cs
│   └── InsertToGCS.cs
│   └── Oauth2Authentication.cs
│   └── packages.config
│   └── UploadfilesToGoogleStorage.cs
│   └── UploadfilesToGoogleStorage.csproj
├── packages
└── UploadfilesToGoogleStorage.sln
```
## Package Information and Dependecies

 - Nuget packages used for Framework 4.5+ (execuitable build on Framework 4.8)
 - Google.Apis version=1.64.0 targetFramework=net48 
 - Google.Apis.Auth version=1.64.0 targetFramework=net48 
 - Google.Apis.Core version=1.64.0 targetFramework=net48 
 - Google.Apis.Iam.v1 version=1.45.0.1904 targetFramework=net461 
 - Google.Apis.Oauth2.v2 version=1.64.0.1869 targetFramework=net48 
 - Google.Apis.Storage.v1 version=1.64.0.3257 targetFramework=net48 
 - Newtonsoft.Json version=13.0.3 targetFramework=net48 
 - System.CodeDom version=7.0.0 targetFramework=net48 
 - System.Interactive.Async version=3.2.0 targetFramework=net461 
 - System.Management version=7.0.2 targetFramework=net48 

All google packages can be download from https://www.nuget.org/.

## API Endpoints
- This scope is related to Google Cloud Storage (GCS), which is a scalable object storage service.
  The devstorage.full_control scope grants full control over GCS, allowing your application to read, 
  write, and manage objects in all your GCS buckets.
  https://www.googleapis.com/auth/devstorage.full_control

## Before You Run It
- Must have a Google Account with billing enabled.
- Good to have business account.
- Google Cloud Account
  - APIs & Services 
  - Credentials 
     - Add Oauth2 ClientID (download the client_screat file)
 - Cloud Storage
    - Create a Bucket (create a new storage)
- Update all the required attributes in the App.config file.

## Using it	
- sample built on Microsoft Visual Studio 2022
- .NET Framework 4.8.
- just build and execuite it is a sample console app.
- can be used for scheduling.

## reference url 
- https://cloud.google.com/storage?hl=en
- https://cloud.google.com/storage/docs/authentication#service_accounts
  
