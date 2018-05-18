CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [ColorId] INT NULL, 
    [SizeId] INT NULL, 
    [PersonId] INT NOT NULL, 
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_Order_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
