CREATE TABLE [dbo].[ProductSizeMap]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [SizeId] INT NOT NULL, 
    CONSTRAINT [FK_ProductSizeMap_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_ProductSizeMap_Size] FOREIGN KEY ([SizeId]) REFERENCES [Size]([Id])
)
