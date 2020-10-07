dotnet ef database update
Invoke-Sqlcmd -ServerInstance "." -Database "TheBank.Application" -InputFile "..\TheBank.Data\SQL\CreateAutidTable.sql"
Invoke-Sqlcmd -ServerInstance "." -Database "TheBank.Application" -InputFile "..\TheBank.Data\SQL\AuditTrigger_Decisions.sql"
Invoke-Sqlcmd -ServerInstance "." -Database "TheBank.Application" -InputFile "..\TheBank.Data\SQL\AuditTrigger_LoanApplications.sql"