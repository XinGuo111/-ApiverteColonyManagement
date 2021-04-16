# CST8334 - Team 5
This project consists of an android app and a web server for the Apiverte Bee Colony Management Tool

- [Backend setup](#backend-setup)
  - [Database](#database)
  - [Server](#server)
  - [Common errors](#common-errors)
- [App setup](#app-setup)

## Backend setup
### Database
The database used for the backend is PostgreSQL. The download and installation steps can be found at the [official website](https://www.postgresql.org/).

Suggested username and password for the server during testing is username: `postgres` password: `password`

### Server
1. Download Visual Studio Community 2019 from the [Visual Studio Website](https://visualstudio.microsoft.com/vs/community/). Be aware that Visual Studio is a very different application from Visual Studio Code!

2. When running the Visual Studio Installer, make sure to select the "Asp.net and Web Development" workload.
![image](https://user-images.githubusercontent.com/33401364/111173594-2ac6a600-857d-11eb-82da-f19d38199415.png)

If you miss this step, you can always run the Visual Studio Installer and click the modify button to go back and add missing workloads
![image](https://user-images.githubusercontent.com/33401364/111173730-4467ed80-857d-11eb-98a6-d3241db0015d.png)

3. If you have not cloned the code from this repository yet, make sure to do so. After VS is done installing, select "Open Project or Solution" under the Get Started options, or if you already have VS open, File > Open >Project/Solution. Navigate to the Server folder of this repository, and select Server.sln

4. Go to the Configuration Manager menu and make sure that "Build" is ticked off.

![image](https://user-images.githubusercontent.com/33401364/111174598-f0113d80-857d-11eb-98d5-b98095d0efe5.png)

![image](https://user-images.githubusercontent.com/33401364/111174695-04553a80-857e-11eb-8e55-c3607e203af4.png)

5. Find `appsettings.Development.json` and change the `ApiverteDbContext` string to match your own PostgreSQL information as necessary. By default the string is set to connect as user postgres with password password

6. Click the green run button. A Visual Studio Debug console should start up, and your browser should open up to a Swagger testing page with all of the application's API endpoints.

#### Common errors
1. `Npgsql.NpgsqlException HResult=0x80004005 Message=Exception while connecting Source=Npgsql StackTrace: ...`

This error appears when trying to start the server application when the Database isn't running. Start the database first and then try again

2. Port conflict

Currently the server is set to use port 4000. If this conflicts with another running application try first to restart your computer and then run the server to see if the port has been freed up. If this is a consistent error on your machine, go to `launchSettings.json`, change the port number under `applicationUrl` and inform the rest of the team

## App setup
WIP
