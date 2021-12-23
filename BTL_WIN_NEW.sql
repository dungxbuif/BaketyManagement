CREATE DATABASE BakeryManagement
GO
USE BakeryManagement

GO
CREATE TABLE [Bill] (
  [idBill] int PRIMARY KEY,
  [idStaff] int,
  [exportDate] datetime NOT NULL,
  [discount] float
)
GO
CREATE TABLE [Staff] (
  [idStaff] int PRIMARY KEY,
  [nameStaff] varchar(255),
  [gender] bit,
  [phone] varchar(255),
  [address] varchar(255)
)
GO
INSERT INTO Staff
VALUES (1,'NGUYEN NGOC DUNG', 1, '0828531788', 'Nguyen Xa - Minh Khai -Bac Tu Liem - Ha Noi')
INSERT INTO Staff
VALUES (2,'NGUYEN TIEN HUY', 1, '0828533245', 'Nguyen Xa - Minh Khai -Bac Tu Liem - Ha Noi')
INSERT INTO Staff
VALUES (3,'NGUYEN VAN HOANG', 1, '0828533256', 'Kieu Mai - Minh Khai -Bac Tu Liem - Ha Noi')
INSERT INTO Staff
VALUES (4,'BUI HUU DUNG', 1, '09974294839', 'Phu Dien - Minh Khai -Bac Tu Liem - Ha Noi')

CREATE TABLE [Salary] (
  [idSalary] int PRIMARY KEY,
  [idStaff] int,
  [salaryDate] float,
  [timeKeeped] date,
  [salaryTime] date,
  [workDay] float,
  [hoursOverTime] float,
  [rewards] float,
  [salaryOverTime] float
)
GO
INSERT INTO Salary VALUES (1, 1, 100000, '2020-12-22', '2020-12-01', 20, 3, 0, 30000)
INSERT INTO Salary VALUES (2, 2, 100000, '2020-12-22', '2020-12-01', 21, 0, 0, 30000)
INSERT INTO Salary VALUES (3, 3, 100000, '2020-12-22', '2020-12-01', 22, 5, 0, 30000)

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

INSERT INTO Account VALUES('DungNN','1', '1', 1)
INSERT INTO Account VALUES('HuyNT','2', '1', 1)
INSERT INTO Account VALUES('HoangNV','3', '1', 1)
INSERT INTO Account VALUES('Admin','4', '1', 0)
GO
CREATE TABLE [Category] (
  [idCategory] int PRIMARY KEY,
  [nameCategory] varchar(255)
)
GO
CREATE TABLE [Supplier] (
  [idSupplier] int PRIMARY KEY,
  [nameSupplier] varchar(255),
  [phone] varchar(255),
  [address] varchar(255)
)
GO
INSERT INTO Supplier VALUES(1,'Huu Nghi','0123456789','Thanh Xuan - Ha Noi')
INSERT INTO Supplier VALUES(2,'Kinh Do','0123456789','Cau Giay - Ha Noi')
INSERT INTO Supplier VALUES(3,'D2H','0123456789','Hai Ba Trung - Ha Noi')
INSERT INTO Supplier VALUES(4,'H2D','0123456789','Dong Da - Ha Noi')
Go
CREATE TABLE [Material] (
  [idMaterial] int PRIMARY KEY,
  [idSupplier] int,
  [nameMaterial] varchar(255),
  [unit] varchar(255)
)
GO
INSERT INTO Material VALUES(1,1,N'Bot my','Kg')
CREATE TABLE [MaterialStore] (
  [idMaterialStore] int PRIMARY KEY,
  [idMaterial] int,
  [amount] float
)
GO
CREATE TABLE [Cake] (
  [idCake] int PRIMARY KEY,
  [idRecipe] int,
  [price] float,
  [Amount] int,
  [expCake] date,
  [mfgCake] date,
  [size] varchar(5)
)
GO

CREATE TABLE [Recipe] (
  [idRecipe] int PRIMARY KEY,
  [price] float,
  [idCategory] int,
  [nameCake] varchar(255)
)
GO

CREATE TABLE [RecipeDetail] (
  [idRecipe] int,
  [idMaterial] int,
  [amount] float,
  PRIMARY KEY ([idMaterial], [idRecipe])
)
GO

CREATE TABLE [Import] (
  [idImport] int PRIMARY KEY,
  [idMaterial] int,
  [amount] float,
  [price] float,
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

ALTER TABLE [Import] ADD FOREIGN KEY ([idMaterial]) REFERENCES [Material] ([idMaterial])
GO
