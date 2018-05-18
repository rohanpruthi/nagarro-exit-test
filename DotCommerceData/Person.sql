CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL IDENTITY , 
    [FirstName] NCHAR(50) NOT NULL, 
    [LastName] NCHAR(50) NULL, 
    [Email] NCHAR(50) NOT NULL, 
    [Password] NCHAR(15) NOT NULL, 
    [Address] NCHAR(100) NULL, 
    [CPassword] NCHAR(15) NOT NULL, 
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id]) 
)
