User
USE master;
GO

DROP DATABASE IF EXISTS DazzlingStore;
CREATE DATABASE DazzlingStore;
GO

USE DazzlingStore;
GO


--Account Start
DROP TABLE IF EXISTS [Role]
CREATE TABLE [Role] (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(200) NOT NULL,
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE()
)
GO

DROP TABLE IF EXISTS Account
CREATE TABLE Account (
  Id INT PRIMARY KEY IDENTITY,
  Email VARCHAR(200) UNIQUE NOT NULL, 
  Password VARCHAR(100) NOT NULL,
  FirstName NVARCHAR(200),
  LastName NVARCHAR(200),
  Gender BIT,
  DoB DATE,
  Avatar VARCHAR(100),-- Optional
  Status BIT DEFAULT 0,
  SecurityCode VARCHAR(50),
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE SocialAccount (
  Id INT PRIMARY KEY IDENTITY,
  AccountId INT NOT NULL,
  Provider NVARCHAR(200) NOT NULL,
  ProviderUserId NVARCHAR(255) NOT NULL,
  AccessToken VARCHAR(MAX) NOT NULL,
  Expiry DATETIME,
  CreatedAt DATETIME DEFAULT GETDATE(),
  FOREIGN KEY (AccountId) REFERENCES Account(Id)
)

--Bảng nhiều nhiều
DROP TABLE IF EXISTS AccountRole
CREATE TABLE AccountRole (
  AccountId INT NOT NULL,
  RoleId INT NOT NULL,
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE(),
  PRIMARY KEY (AccountId, RoleId),
  FOREIGN KEY (AccountId) REFERENCES Account(Id),
  FOREIGN KEY (RoleId) REFERENCES Role(Id),
)
GO

DROP TABLE IF EXISTS [AddressProfile]
CREATE TABLE [AddressProfile] (
  Id INT PRIMARY KEY IDENTITY,
  AccountId INT NOT NULL,
  FirstName NVARCHAR(200),
  LastName NVARCHAR(200),
  Phone VARCHAR(20),
  Street NVARCHAR(200) NOT NULL,
  Ward NVARCHAR(200) NOT NULL,
  District NVARCHAR(200) NOT NULL,
  City NVARCHAR(200) NOT NULL,
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE(),
  FOREIGN KEY (AccountId) REFERENCES Account(Id),
)
GO
--Account End


--Product Start
DROP TABLE IF EXISTS Category
CREATE TABLE Category (
  Id INT PRIMARY KEY IDENTITY,
  [Name] INT NOT NULL,
  ParentId INT NOT NULL,
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE(),
  FOREIGN KEY (ParentId) REFERENCES Category(Id),
)
GO

DROP TABLE IF EXISTS Size
CREATE TABLE Size (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(200) NOT NULL,
  Description NVARCHAR(255),
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE Color (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(200) NOT NULL,
  HexCode VARCHAR(7),
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE()
)
GO

DROP TABLE IF EXISTS Product
CREATE TABLE Product (
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(200) NOT NULL,
  SubDescription NTEXT,
  Description NTEXT,
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE()
)
GO

DROP TABLE IF EXISTS ProductImage
CREATE TABLE ProductImage (
  Id INT PRIMARY KEY IDENTITY,
  [Image] NVARCHAR(200) NOT NULL,
  IndexOf INT,
  ProductId INT NOT NULL,
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE(),
  FOREIGN KEY (ProductId) REFERENCES Product(Id)
)
GO

DROP TABLE IF EXISTS ProductCategory
CREATE TABLE ProductCategory (
  ProductId INT NOT NULL,
  CategoryId INT NOT NULL,
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE(),
  PRIMARY KEY (ProductId, CategoryId),
  FOREIGN KEY (ProductId) REFERENCES Product(Id),
  FOREIGN KEY (CategoryId) REFERENCES Category(Id)
)
GO

DROP TABLE IF EXISTS ProductItem
CREATE TABLE ProductItem (
  Id INT PRIMARY KEY,
  -- phân loại 
  ProductId INT NOT NULL,
  SizeId INT NOT NULL,
  ColorId INT NOT NULL,
  -- đặc điểm của 1 item 
  Quantity INT NOT NULL,
  Price INT NOT NULL, -- Giá nhập
  Cost INT NOT NULL, -- Giá bán ra
  SaleCost INT NOT NULL,-- Giá bán ra đã giảm
  ImageOfProductItem NVARCHAR(100) NOT NULL,
  [Status] BIT NOT NULL,
  [Hot] BIT NOT NULL,
  Sale BIT DEFAULT 0,
  --Phụ
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE(),
  FOREIGN KEY (ProductId) REFERENCES Product(Id),
  FOREIGN KEY (SizeId) REFERENCES Size(Id),
  FOREIGN KEY (ColorId) REFERENCES Color(Id),
)
GO

--Product End

--Review START
DROP TABLE IF EXISTS Review
CREATE TABLE Review (
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL,
	ProductId INT NOT NULL,
	Content TEXT,
	Rating TINYINT NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (AccountId) REFERENCES Account(Id),
	FOREIGN KEY (ProductId) REFERENCES Product(Id)
)
GO
--Review END


--Event Start
DROP TABLE IF EXISTS Event
CREATE TABLE Event (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Photo VARCHAR(200) NOT NULL,
	Description NTEXT,
	StartTime DATETIME NOT NULL, -- thời gian bắt đầu sự kiện
	StartEnd DATETIME NOT NULL, -- thời gian kết thúc sự kiện
 	CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE(),
)
GO

DROP TABLE IF EXISTS EventDetail
CREATE TABLE EventDetail (
	ProductItemId INT NOT NULL,
	EventId INT NOT NULL,
	Price INT NOT NULL,-- Giá bán ra đã giảm
	LimitedQuantity INT NOT NULL, -- Số lượng giới hạn giảm giá
	RemainingQuantity INT NOT NULL, -- Số lượng còn lại
 	CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE(),
	PRIMARY KEY(ProductItemId,EventId),
	FOREIGN KEY (ProductItemId) REFERENCES ProductItem(Id),
	FOREIGN KEY (EventId) REFERENCES Event(Id)
)
GO
--Event End

-- Wishlist Start
DROP TABLE IF EXISTS Wishlist
CREATE TABLE Wishlist (
    Id INT PRIMARY KEY IDENTITY,
    AccountId INT NOT NULL, -- Thông tin người dùng đang sử dụng wishlist
    ProductItemId INT NOT NULL, -- Sản phẩm được thêm vào wishlist
    AddedAt DATETIME DEFAULT GETDATE(), -- Thời gian khi sản phẩm được thêm vào wishlist
    FOREIGN KEY (AccountId) REFERENCES Account(Id), -- Ràng buộc ngoại
    FOREIGN KEY (ProductItemId) REFERENCES ProductItem(Id) -- Ràng buộc ngoại
)
-- Wishlist End

--Order Start 
DROP TABLE IF EXISTS OrderStatus
CREATE TABLE OrderStatus (
  Id INT PRIMARY KEY IDENTITY,
  Name VARCHAR(100) NOT NULL,
  Description NTEXT,
  CreatedAt DATETIME DEFAULT GETDATE(),
  UpdatedAt DATETIME DEFAULT GETDATE(),	
)
GO

DROP TABLE IF EXISTS PaymentMethod
CREATE TABLE PaymentMethod (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Status BIT NOT NULL,
	Icon NVARCHAR(200) NOT NULL,
	Description NTEXT,
	CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE()
)
GO

DROP TABLE IF EXISTS Invoice
CREATE TABLE Invoice (
    Id INT PRIMARY KEY IDENTITY(1,1),
    InvoiceNumber INT NOT NULL,
    PaymentMethodId INT,
    AccountId INT NOT NULL,
    TotalAmount DECIMAL(18, 2),
    InvoiceDate DATETIME,
    DueDate DATETIME,
    Status BIT NOT NULL,
    Description NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (AccountId) REFERENCES Account(Id),
	FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethod(Id)
)
GO

DROP TABLE IF EXISTS InvoiceDetail
CREATE TABLE InvoiceDetail (
	InvoiceId INT NOT NULL,
	ProductItemId INT NOT NULL,
	Quantity INT NOT NULL,
	Cost INT NOT NULL,
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY (InvoiceId,ProductItemId),
	FOREIGN KEY (InvoiceId) REFERENCES Invoice(Id),
	FOREIGN KEY (ProductItemId) REFERENCES ProductItem(Id),
)
GO


DROP TABLE IF EXISTS Voucher
CREATE TABLE Voucher (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(200) UNIQUE NOT NULL,
    VarietyCode VARCHAR(10) UNIQUE NOT NULL,
    Discount DECIMAL(5, 2) NOT NULL, -- Sử dụng kiểu dữ liệu DECIMAL để lưu trữ phần trăm giảm giá
    Condition DECIMAL(18, 2) NOT NULL, -- Điều kiện sử dụng voucher (nếu cần)
    Quantity INT NOT NULL, -- Số lượng voucher có sẵn
    TimeStart DATETIME NOT NULL DEFAULT GETDATE(),
    TimeEnd DATETIME NOT NULL,
    Status BIT NOT NULL DEFAULT 1, -- Trạng thái hoạt động (1: hoạt động, 0: không hoạt động)
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()
)
GO

DROP TABLE IF EXISTS Orders
CREATE TABLE Orders (
  Id INT PRIMARY KEY IDENTITY(1,1),
  AccountId INT NOT NULL,
  TotalPrice DECIMAL(18,2) NOT NULL,
  StatusId INT NOT NULL,
  AddressId INT NOT NULL,
  VoucherId INT,
  PaymentMethodId INT NOT NULL,
  InvoiceId INT,
  OrderDate DATETIME NOT NULL DEFAULT GETDATE(), -- Thêm trường ngày đặt hàng
  ShippingDate DATETIME, -- Thêm trường ngày giao hàng (nếu cần)
  Note NTEXT, -- Thêm trường ghi chú đơn hàng
  CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
  UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),
  FOREIGN KEY (AccountId) REFERENCES Account(Id),
  FOREIGN KEY (StatusId) REFERENCES OrderStatus(Id),
  FOREIGN KEY (AddressId) REFERENCES AddressProfile(Id), -- Sửa tên bảng [AddressProfile]
  FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethod(Id),
  FOREIGN KEY (InvoiceId) REFERENCES Invoice(Id),
  FOREIGN KEY (VoucherId) REFERENCES Voucher(Id) -- Sửa tên bảng [Voucher]
)
GO


DROP TABLE IF EXISTS OrderDetail
CREATE TABLE OrderDetail (
	OrderId INT NOT NULL,
	ProductItemId INT NOT NULL,
	Quantity DECIMAL(18,2) NOT NULL,
	Cost INT NOT NULL,
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY (OrderId,ProductItemId),
	FOREIGN KEY (OrderId) REFERENCES Orders(Id),
	FOREIGN KEY (ProductItemId) REFERENCES ProductItem(Id),
)
GO

--Order End