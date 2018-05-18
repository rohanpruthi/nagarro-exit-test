CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NCHAR(100) NOT NULL, 
    [Description] NCHAR(500) NULL , 
    [CategoryId] INT NOT NULL, 
    [Price] NCHAR(10) NOT NULL, 
    [Image] IMAGE NULL, 
    [StockId] INT NOT NULL, 
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]) 
)
