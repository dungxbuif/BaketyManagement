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
INSERT INTO Bill
VALUES (1,1, '2021-12-12', 10)
INSERT INTO Bill
VALUES (2,1, '2021-12-1', 10)
GO
CREATE TABLE [Staff] (
  [idStaff] int PRIMARY KEY,
  [nameStaff] nvarchar(255),
  [gender] bit,
  [phone] varchar(255),
  [address] nvarchar(255)
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
INSERT INTO Salary VALUES (1, 1, 100000, '2021-12-22', '2021-12-01', 20, 3, 0, 30000)
INSERT INTO Salary VALUES (2, 2, 100000, '2021-12-22', '2021-12-01', 21, 0, 0, 30000)
INSERT INTO Salary VALUES (3, 3, 100000, '2021-12-22', '2021-12-01', 22, 5, 0, 30000)

CREATE TABLE [BilDetail] (
  [idBill] int,
  [idCake] int,
  [amountOrder] int,
  PRIMARY KEY ([idBill], [idCake])
)
GO
INSERT INTO BilDetail VALUES (1, 1, 10)
INSERT INTO BilDetail VALUES (1, 2, 5)
INSERT INTO BilDetail VALUES (2, 1, 13)

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
  [nameCategory] nvarchar(255)
)
GO
INSERT INTO Category VALUES(1,N'Bánh quy')
INSERT INTO Category VALUES(2,N'Bánh trung thu')
INSERT INTO Category VALUES(3,N'Bánh gato')
INSERT INTO Category VALUES(4,N'Bánh mỳ')
INSERT INTO Category VALUES(5,N'Quick bread')
INSERT INTO Category VALUES(6,N'Bánh hoa quả')
INSERT INTO Category VALUES(7,N'Tráng miệng')
GO
CREATE TABLE [Supplier] (
  [idSupplier] int PRIMARY KEY,
  [nameSupplier] nvarchar(255),
  [phone] varchar(255),
  [address] nvarchar(255)
)
GO
INSERT INTO Supplier VALUES(1,N'Hữu Nghị','0123456789',N'Thanh Xuân - Hà Nội')
INSERT INTO Supplier VALUES(2,N'Kinh Đô','0123456789',N'Đống Đa - Hà Nội')
INSERT INTO Supplier VALUES(3,N'Mixi Food','0123456789',N'Láng Hạ - Hà Nội')
INSERT INTO Supplier VALUES(4,N'Haki Food','0123456789',N'Hoài Đức - Hà Nội')
Go
CREATE TABLE [Material] (
  [idMaterial] int PRIMARY KEY,
  [idSupplier] int,
  [nameMaterial] nvarchar(255),
  [unit] nvarchar(255)
)
GO
INSERT INTO Material VALUES(1,1,N'Bột mỳ','Kg')
INSERT INTO Material VALUES(2,1,N'Bột nở','Kg')
INSERT INTO Material VALUES(3,1,N'Bột bắp','Kg')
INSERT INTO Material VALUES(4,2,N'Socola','Kg')
INSERT INTO Material VALUES(5,2,N'Sữa','lọ')
INSERT INTO Material VALUES(6,2,N'Vani','lọ')
INSERT INTO Material VALUES(7,3,N'Màu thực phẩm','lọ')
INSERT INTO Material VALUES(8,3,N'Bơ','Kg')
INSERT INTO Material VALUES(9,3,N'Siro','lọ')
INSERT INTO Material VALUES(10,4,N'Kem','bình')
INSERT INTO Material VALUES(11,4,N'Đường','Kg')
INSERT INTO Material VALUES(12,4,N'Mứt','lọ')
INSERT INTO Material VALUES(13,1,N'Hạnh nhân','Kg')
INSERT INTO Material VALUES(14,2,N'Hạt óc chó','Kg')
INSERT INTO Material VALUES(15,3,N'Dừa sợi','túi')
INSERT INTO Material VALUES(16,4,N'Cốt dừa','lít')
INSERT INTO Material VALUES(17,1,N'Bột matcha','kg')
INSERT INTO Material VALUES(18,1,N'Trứng','quả')
CREATE TABLE [MaterialStore] (
  [idMaterialStore] int PRIMARY KEY,
  [idMaterial] int,
  [amount] float
)
GO
INSERT INTO MaterialStore VALUES(1,1,10)
INSERT INTO MaterialStore VALUES(2,2,10)
INSERT INTO MaterialStore VALUES(3,3,10)
INSERT INTO MaterialStore VALUES(4,4,10)
INSERT INTO MaterialStore VALUES(5,5,10)
INSERT INTO MaterialStore VALUES(6,6,10)
INSERT INTO MaterialStore VALUES(7,7,10)
INSERT INTO MaterialStore VALUES(8,8,10)
INSERT INTO MaterialStore VALUES(9,9,10)
INSERT INTO MaterialStore VALUES(10,10,10)
INSERT INTO MaterialStore VALUES(11,11,10)
INSERT INTO MaterialStore VALUES(12,12,10)
INSERT INTO MaterialStore VALUES(13,13,10)
INSERT INTO MaterialStore VALUES(14,14,10)
INSERT INTO MaterialStore VALUES(15,15,10)
INSERT INTO MaterialStore VALUES(16,16,10)
CREATE TABLE [Cake] (
  [idCake] int PRIMARY KEY,
  [idRecipe] int,
  [price] float,
  [Amount] int,
  [expCake] date,
  [mfgCake] date,
  [size] nvarchar(5)
)
GO
INSERT INTO Cake VALUES(1,1,15000,20,'2021-12-31','2021-12-20',N'vừa')
INSERT INTO Cake VALUES(2,2,15000,20,'2021-12-31','2021-12-20',N'lớn')
CREATE TABLE [Recipe] (
  [idRecipe] int PRIMARY KEY,
  [price] float,
  [idCategory] int,
  [nameCake] nvarchar(255)
)
GO
INSERT INTO Recipe VALUES(1,10000,7,N'Bông lan trứng muối')
INSERT INTO Recipe VALUES(2,10000,3,N'Bánh sinh nhật matcha')
CREATE TABLE [RecipeDetail] (
  [idRecipe] int,
  [idMaterial] int,
  [amount] float,
  PRIMARY KEY ([idMaterial], [idRecipe])
)
GO
INSERT INTO RecipeDetail VALUES(1,1,0.2)
INSERT INTO RecipeDetail VALUES(1,5,1)
INSERT INTO RecipeDetail VALUES(1,18,4)
INSERT INTO RecipeDetail VALUES(2,1,0.2)
INSERT INTO RecipeDetail VALUES(2,5,1)
INSERT INTO RecipeDetail VALUES(2,17,0.1)
CREATE TABLE [Import] (
  [idImport] int PRIMARY KEY,
  [idMaterial] int,
  [amount] float,
  [price] float,
  [createdAt] datetime
)
GO
INSERT INTO Import VALUES(1,1,10,10000,2021-12-1)
INSERT INTO Import VALUES(2,2,10,10000,2021-12-1)
INSERT INTO Import VALUES(3,3,10,10000,2021-12-1)
INSERT INTO Import VALUES(4,4,10,10000,2021-12-1)
INSERT INTO Import VALUES(5,5,10,10000,2021-12-1)
INSERT INTO Import VALUES(6,6,10,10000,2021-12-1)
INSERT INTO Import VALUES(7,7,10,10000,2021-12-1)
INSERT INTO Import VALUES(8,8,10,10000,2021-12-1)
INSERT INTO Import VALUES(9,9,10,10000,2021-12-1)
INSERT INTO Import VALUES(10,10,10,10000,2021-12-1)
INSERT INTO Import VALUES(11,11,10,10000,2021-12-1)
INSERT INTO Import VALUES(12,12,10,10000,2021-12-1)
INSERT INTO Import VALUES(13,13,10,10000,2021-12-1)
INSERT INTO Import VALUES(14,14,10,10000,2021-12-1)
INSERT INTO Import VALUES(15,15,10,10000,2021-12-1)
INSERT INTO Import VALUES(16,16,10,10000,2021-12-1)
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
