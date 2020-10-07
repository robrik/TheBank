Invoke-Sqlcmd -ServerInstance "." -Database "TheBank.Application" -InputFile ".\SQL\CreateAutidTable.sql"
Invoke-Sqlcmd -ServerInstance "." -Database "TheBank.Application" -InputFile ".\SQL\AuditTrigger_Decisions.sql"
Invoke-Sqlcmd -ServerInstance "." -Database "TheBank.Application" -InputFile ".\SQL\AuditTrigger_LoanApplications.sql"