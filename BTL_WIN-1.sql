CREATE DATABASE BakeryManagement
GO
USE BakeryManagement

GO
CREATE TABLE [Bill] (
  [idBill] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [idStaff] int,
  [exportDate] datetime NOT NULL,
  [discount] float
)
GO
CREATE TABLE [Staff] (
  [idStaff] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [nameStaff] varchar(255),
  [gender] bit,
  [phone] varchar(255),
  [address] varchar(255)
)
GO
INSERT INTO Staff
VALUES ('NGUYEN NGOC DUNG', 1, '0828531788', 'Nguyen Xa - Minh Khai -Bac Tu Liem - Ha Noi')
INSERT INTO Staff
VALUES ('NGUYEN TIEN HUY', 1, '0828533245', 'Nguyen Xa - Minh Khai -Bac Tu Liem - Ha Noi')
INSERT INTO Staff
VALUES ('NGUYEN VAN HOANG', 1, '0828533256', 'Kieu Mai - Minh Khai -Bac Tu Liem - Ha Noi')
INSERT INTO Staff
VALUES ('BUI HUU DUNG', 1, '09974294839', 'Phu Dien - Minh Khai -Bac Tu Liem - Ha Noi')

CREATE TABLE [Salary] (
  [idSalary] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [idStaff] int,
  [salaryDate] float,
  [timeKeeped] date,
  [lastTimeKeeped] date,
  [salaryTime] date,
  [workDay] float,
  [hoursOverTime] float,
  [rewards] float,
  [salaryOverTime] float
)
GO

CREATE TABLE [BilDetail] (
  [idBill] int,
  [idCake] int,
  [amountOrder] int,
  PRIMARY KEY ([idBill], [idCake])
)
GO

CREATE TABLE [Account] (
  [userName] varchar(255) PRIMARY KEY,
  [idStaff] int,
  [pass] varchar(255),
  [typeAccount] bit
)

INSERT INTO Account VALUES('DungNN','1', '123', 1)
INSERT INTO Account VALUES('HuyNT','2', '123', 1)
INSERT INTO Account VALUES('HoangNV','3', '123', 1)
INSERT INTO Account VALUES('DungBH','4', '123456', 0)
GO
CREATE TABLE [Category] (
  [idCategory] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [nameCategory] varchar(255)
)
GO
CREATE TABLE [Supplier] (
  [idSupplier] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [nameSupplier] varchar(255),
  [phone] varchar(255),
  [address] varchar(255)
)
GO

CREATE TABLE [Material] (
  [idMaterial] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [idSupplier] int,
  [nameMaterial] varchar(255),
  [unit] varchar(255)
)
GO

CREATE TABLE [MaterialStore] (
  [idMaterialStore] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [idMaterial] int,
  [amount] float
)
GO

CREATE TABLE [Cake] (
  [idCake] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [idRecipe] int,
  [price] float,
  [Amount] int,
  [expCake] date,
  [mfgCake] date,
  [size] varchar(5)
)
GO

CREATE TABLE [Recipe] (
  [idRecipe] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [idCategory] int,
  [nameCake] varchar(255)
)
GO

CREATE TABLE [RecipeDetail] (
  [idMaterial] int,
  [idRecipe] int,
  [amount] float,
  [price] float,
  PRIMARY KEY ([idMaterial], [idRecipe])
)
GO

CREATE TABLE [ImportDetail] (
  [idMaterial] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [idImport] int,
  [amount] float,
  [price] float,
  [createdAt] datetime
)
GO

CREATE TABLE [Import] (
  [idImport] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [createdAt] datetime
)
GO

CREATE TABLE [Export] (
  [idExport] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [idRecipe] int,
  [amount] int,
  [createdAt] datetime
)
GO

ALTER TABLE [Bill] ADD FOREIGN KEY ([idStaff]) REFERENCES [Staff] ([idStaff])
GO

ALTER TABLE [Salary] ADD FOREIGN KEY ([idStaff]) REFERENCES [Staff] ([idStaff])
GO

ALTER TABLE [BilDetail] ADD FOREIGN KEY ([idCake]) REFERENCES [Cake] ([idCake])
GO

ALTER TABLE [BilDetail] ADD FOREIGN KEY ([idBill]) REFERENCES [Bill] ([idBill])
GO

ALTER TABLE [Recipe] ADD FOREIGN KEY ([idCategory]) REFERENCES [Category] ([idCategory])
GO

ALTER TABLE [Material] ADD FOREIGN KEY ([idSupplier]) REFERENCES [Supplier] ([idSupplier])
GO

ALTER TABLE [MaterialStore] ADD FOREIGN KEY ([idMaterial]) REFERENCES [Material] ([idMaterial])
GO

ALTER TABLE [Account] ADD FOREIGN KEY ([idStaff]) REFERENCES [Staff] ([idStaff])
GO

ALTER TABLE [Cake] ADD FOREIGN KEY ([idRecipe]) REFERENCES [Recipe] ([idRecipe])
GO

ALTER TABLE [RecipeDetail] ADD FOREIGN KEY ([idMaterial]) REFERENCES [Material] ([idMaterial])
GO

ALTER TABLE [RecipeDetail] ADD FOREIGN KEY ([idRecipe]) REFERENCES [Recipe] ([idRecipe])
GO

ALTER TABLE [ImportDetail] ADD FOREIGN KEY ([idMaterial]) REFERENCES [Material] ([idMaterial])
GO

ALTER TABLE [ImportDetail] ADD FOREIGN KEY ([idMaterial]) REFERENCES [Import] ([idImport])
GO

ALTER TABLE [Export] ADD FOREIGN KEY ([idRecipe]) REFERENCES [Recipe] ([idRecipe])
GO

