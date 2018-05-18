CREATE TABLE [dbo].[Stock]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [StockCount] INT NOT NULL, 
    [VariantId] INT NULL, 
    CONSTRAINT [FK_Stock_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
