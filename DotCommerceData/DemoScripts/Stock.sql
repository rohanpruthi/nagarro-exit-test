CREATE TABLE [dbo].[Stock]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [StockCount] INT NOT NULL, 
    [ColorId] INT NULL, 
    [SizeId] INT NULL, 
    CONSTRAINT [FK_Stock_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
