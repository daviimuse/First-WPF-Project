CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [usrn] VARCHAR(50) NOT NULL, 
    [mail] VARCHAR(50) NOT NULL, 
    [name] VARCHAR(50) NOT NULL, 
    [surname] VARCHAR(50) NOT NULL, 
    [psw] CHAR(32) NOT NULL
)
