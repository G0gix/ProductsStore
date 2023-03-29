-- Create table [dbo].[Categories]
Print 'Create table [dbo].[Categories]'
CREATE TABLE [dbo].[Categories](
  [Id] [int] IDENTITY (1,1) NOT NULL,
  [Name] [nvarchar](50)  NOT NULL,
  CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id]),
);
GO

-- Create table [dbo].[Category_Fields]
Print 'Create table [dbo].[Category_Fields]'
CREATE TABLE [dbo].[Category_Fields](
  [Category_Id] [int]  NOT NULL,
  [Field_Id] [int]  NOT NULL,
);
GO

-- Create table [dbo].[ProductFields]
Print 'Create table [dbo].[ProductFields]'
CREATE TABLE [dbo].[ProductFields](
  [ProductId] [int]  NOT NULL,
  [Field_Id] [int]  NOT NULL,
  [Value] [nvarchar](50)  NULL,
);
GO

-- Create table [dbo].[Fields]
Print 'Create table [dbo].[Fields]'
CREATE TABLE [dbo].[Fields](
  [ID] [int] IDENTITY (1,1) NOT NULL,
  [Name] [nvarchar](50)  NOT NULL,
  CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED ([ID]),
);
GO

-- Create table [dbo].[Products]
Print 'Create table [dbo].[Products]'
CREATE TABLE [dbo].[Products](
  [Id] [int] IDENTITY (1,1) NOT NULL,
  [Name] [nvarchar](50)  NOT NULL,
  [Description] [nvarchar](50)  NULL,
  [Photo] [varbinary](MAX)  NULL,
  [CategoryId] [int]  NOT NULL,
  CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id]),
);
GO

-- Add relationship [FK_Category_Fields_Fields] to table [dbo].[Category_Fields]'
Print 'Add relationship [FK_Category_Fields_Fields] to table [dbo].[Category_Fields]'
ALTER TABLE [dbo].[Category_Fields]
  ADD CONSTRAINT [FK_Category_Fields_Fields] FOREIGN KEY ([Field_Id]) REFERENCES [dbo].[Fields] 
([ID]);
GO
-- Add relationship [FK_Category_Fields_Categories1] to table [dbo].[Category_Fields]'
Print 'Add relationship [FK_Category_Fields_Categories1] to table [dbo].[Category_Fields]'
ALTER TABLE [dbo].[Category_Fields]
  ADD CONSTRAINT [FK_Category_Fields_Categories1] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Categories] 
([Id]);
GO
-- Add relationship [FK_ProductFields_Fields] to table [dbo].[ProductFields]'
Print 'Add relationship [FK_ProductFields_Fields] to table [dbo].[ProductFields]'
ALTER TABLE [dbo].[ProductFields]
  ADD CONSTRAINT [FK_ProductFields_Fields] FOREIGN KEY ([Field_Id]) REFERENCES [dbo].[Fields] 
([ID]);
GO
-- Add relationship [FK_ProductFields_Products] to table [dbo].[ProductFields]'
Print 'Add relationship [FK_ProductFields_Products] to table [dbo].[ProductFields]'
ALTER TABLE [dbo].[ProductFields]
  ADD CONSTRAINT [FK_ProductFields_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] 
([Id]);
GO
-- Add relationship [FK_Products_Categories] to table [dbo].[Products]'
Print 'Add relationship [FK_Products_Categories] to table [dbo].[Products]'
ALTER TABLE [dbo].[Products]
  ADD CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] 
([Id]);
GO

