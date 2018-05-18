CREATE TABLE [dbo].[ProductColorMap]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    CONSTRAINT [FK_ProductColorMap_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_ProductColorMap_Color] FOREIGN KEY ([ColorId]) REFERENCES [Color]([Id])
)
