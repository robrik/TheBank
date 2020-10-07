1. If you dont have the SqlServer module for powershell installed, run in powershell: Install-Module -Name SqlServer , your user need to be able to create databases.
	https://docs.microsoft.com/en-us/sql/powershell/download-sql-server-ps-module?view=sql-server-ver15
2. Add Database and Tiggers for logging (audit trail) - Run the powershell script in TheBank.Api: SetupDatabase.ps1
3. Run IISExpress Visual Studio to host the API.
4. Use the Swagger UI to test play with the API.



Known issues
	Security (currently none)
	Input validation
	Database tests
	Unit tests on some small objects
