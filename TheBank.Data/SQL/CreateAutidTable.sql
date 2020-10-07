    CREATE TABLE [dbo].[Audit](
    [AuditID] [int] IDENTITY(1,1) NOT NULL,
    [Type] [char](1) NULL,
    [TableName] [varchar](128) NULL,
    [PK] [varchar](1000) NULL,
    [FieldName] [varchar](128) NULL,
    [OldValue] [varchar](1000) NULL,
    [NewValue] [varchar](1000) NULL,
    [UpdateDate] [datetime] NULL,
    [UserName] [varchar](128) NULL,
 CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED 
(
    [AuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
Go