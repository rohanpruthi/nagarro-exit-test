CREATE TABLE [dbo].[OrderDetail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [PersonId] INT NOT NULL, 
    [VariantId] INT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_OrderDetail_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]) 
)
