CREATE TABLE [dbo].[OrderDetail]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [OrderId] INT NOT NULL, 
    [ProductId] INT NULL, 
    [ColorId] INT NULL, 
    [SizeId] INT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id])
)
