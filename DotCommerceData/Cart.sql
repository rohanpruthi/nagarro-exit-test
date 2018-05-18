CREATE TABLE [dbo].[Cart]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductVariantId] INT NOT NULL, 
    [PersonId] INT NULL, 
    CONSTRAINT [FK_Cart_ProductVariant] FOREIGN KEY ([ProductVariantId]) REFERENCES [ProductVariant]([Id]), 
    CONSTRAINT [FK_Cart_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
