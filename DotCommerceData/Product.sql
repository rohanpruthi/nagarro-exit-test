CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NCHAR(100) NOT NULL, 
    [Description] NCHAR(500) NULL , 
    [CategoryId] INT NOT NULL, 
    [Price] NCHAR(10) NOT NULL, 
    [Image] NCHAR(50) NULL, 
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]) 
)
