CREATE TABLE [dbo].[ProductVariant]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [VariantId] INT NOT NULL, 
    [VariantTitle] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_ProductVariant_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
