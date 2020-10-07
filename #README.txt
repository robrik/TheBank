1. Create Local Db - In Nuget Packet Manager run: Update-Database (might need to select project TheBank.Data)
2. If you dont have the SqlServer module for powershell installed, run in powershell: Install-Module -Name SqlServer
	https://docs.microsoft.com/en-us/sql/powershell/download-sql-server-ps-module?view=sql-server-ver15
3. Add Table and Tiggers for logging (audit trail) - Run: .\TheBank.Data\SetupDatabase.ps1
4. Run IISExpress Visual Studio to host the API.
5. Use the Swagger UI to test play with the API.
