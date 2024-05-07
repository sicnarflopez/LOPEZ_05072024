# LOPEZ_05072024
.NET Core Coding Challenge

Challenge Overview:
Develop a RESTful web service in C# that securely processes uploaded files and returns the results. The
service should support either CSV or JSON (your choice) file formats and include an API Key-based
security mechanism. Additionally, it should track the files processed and provide basic reporting of these
files upon request. The goal is not necessarily to fully complete the work, but to give a solid
representation of how you accomplish the work.

# Technologies
- .NET 8
- CQRS
- Mediatr
- Docker
- Serilog for logging and tracking of files.
- Global exception handling under Application/Common/Behaviours

# Development
- Open .sln in Visual Studio 2022
- Has two layers: API and Application.
- **API**: Web API with Swagger. Docker file is also here
- **Application**: Includes logic and services
- Configure API Key in appsettings.json **Authentication: ApiKey**
- Build and run the code.

# Running and Testing Code
1. Run through VS 2022 and use Swagger.
2. Postman: use cUrl : 
</br>
<i>curl --location 'https://localhost:7120/File/process-file' \
--header 'x-api-key: 8DBE325B-F9D1-4C11-980D-C3C5C4C12EFB' \
--form 'csvfile=@"/D:/Projects/Lopez_05072024/TestCsvFile.csv"'<i>

* Replace the localhost port depending on your local.

**NOTE** : Use test TestCsvFile.csv or you can create a new file with two columns: Name and Score. Make sure to provide the right columns and able to attach the file as it will return an error in validation.
