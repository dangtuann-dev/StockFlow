-- ============================================================
--  WAREHOUSE INVENTORY MANAGEMENT SYSTEM
--  SQL Server Script
--  Bao gom: Tao Database, Tables, Constraints, Du lieu mau
-- ============================================================


-- ============================================================
-- 1. TAO DATABASE
-- ============================================================
USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'StockFlowDb')
BEGIN
    ALTER DATABASE StockFlowDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE StockFlowDb;
END
GO

CREATE DATABASE StockFlowDb
    COLLATE Vietnamese_CI_AS;
GO

USE StockFlowDb;
GO

PRINT '>>> Database StockFlowDb da duoc tao thanh cong.';
GO


-- ============================================================
-- 2. TAO CAC BANG
-- ============================================================

-- ------------------------------------------------------------
-- Bang USERS: Tai khoan nguoi dung he thong
-- ------------------------------------------------------------
CREATE TABLE USERS (
    UserID      INT           IDENTITY(1,1)     NOT NULL,
    UserName    NVARCHAR(50)                    NOT NULL,
    FullName    NVARCHAR(100)                   NOT NULL,
    Password    NVARCHAR(255)                   NOT NULL,
    Phone       NVARCHAR(15)                    NULL,
    CreatedAt   DATETIME      DEFAULT GETDATE() NOT NULL,

    CONSTRAINT PK_USERS            PRIMARY KEY (UserID),
    CONSTRAINT UQ_USERS_UserName   UNIQUE      (UserName),
    CONSTRAINT CHK_USERS_Phone     CHECK       (Phone IS NULL OR Phone LIKE '[0-9]%'),
    CONSTRAINT CHK_USERS_UserName  CHECK       (LEN(UserName) >= 3)
);
GO

PRINT '>>> Bang USERS da duoc tao.';
GO


-- ------------------------------------------------------------
-- Bang CATEGORIES: Danh muc san pham
-- ------------------------------------------------------------
CREATE TABLE CATEGORIES (
    CategoryID  INT           IDENTITY(1,1)     NOT NULL,
    Name        NVARCHAR(100)                   NOT NULL,
    CreatedAt   DATETIME      DEFAULT GETDATE() NOT NULL,

    CONSTRAINT PK_CATEGORIES       PRIMARY KEY (CategoryID),
    CONSTRAINT UQ_CATEGORIES_Name  UNIQUE      (Name),
    CONSTRAINT CHK_CATEGORIES_Name CHECK       (LEN(LTRIM(RTRIM(Name))) > 0)
);
GO

PRINT '>>> Bang CATEGORIES da duoc tao.';
GO


-- ------------------------------------------------------------
-- Bang PRODUCTS: San pham trong kho
-- ------------------------------------------------------------
CREATE TABLE PRODUCTS (
    ProductID   INT           IDENTITY(1,1)     NOT NULL,
    Name        NVARCHAR(150)                   NOT NULL,
    Quantity    INT           DEFAULT 0         NOT NULL,
    Description NVARCHAR(500)                   NULL,
    CategoryID  INT                             NOT NULL,
    CreatedAt   DATETIME      DEFAULT GETDATE() NOT NULL,

    CONSTRAINT PK_PRODUCTS          PRIMARY KEY (ProductID),
    CONSTRAINT FK_PRODUCTS_CATEGORY FOREIGN KEY (CategoryID)
        REFERENCES CATEGORIES(CategoryID)
        ON UPDATE CASCADE
        ON DELETE NO ACTION,
    CONSTRAINT CHK_PRODUCTS_Quantity CHECK (Quantity >= 0),
    CONSTRAINT CHK_PRODUCTS_Name     CHECK (LEN(LTRIM(RTRIM(Name))) > 0)
);
GO

PRINT '>>> Bang PRODUCTS da duoc tao.';
GO


-- ------------------------------------------------------------
-- Bang CUSTOMERS: Khach hang
-- ------------------------------------------------------------
CREATE TABLE CUSTOMERS (
    CustomerID  INT           IDENTITY(1,1)     NOT NULL,
    Name        NVARCHAR(100)                   NOT NULL,
    CreatedAt   DATETIME      DEFAULT GETDATE() NOT NULL,

    CONSTRAINT PK_CUSTOMERS      PRIMARY KEY (CustomerID),
    CONSTRAINT CHK_CUSTOMERS_Name CHECK       (LEN(LTRIM(RTRIM(Name))) > 0)
);
GO

PRINT '>>> Bang CUSTOMERS da duoc tao.';
GO


-- ------------------------------------------------------------
-- Bang ORDERS: Don hang
-- ------------------------------------------------------------
CREATE TABLE ORDERS (
    OrderID     INT           IDENTITY(1,1)              NOT NULL,
    CustomerID  INT                                      NOT NULL,
    OrderDate   DATE          DEFAULT CAST(GETDATE() AS DATE) NOT NULL,
    CreatedAt   DATETIME      DEFAULT GETDATE()          NOT NULL,

    CONSTRAINT PK_ORDERS           PRIMARY KEY (OrderID),
    CONSTRAINT FK_ORDERS_CUSTOMERS FOREIGN KEY (CustomerID)
        REFERENCES CUSTOMERS(CustomerID)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

PRINT '>>> Bang ORDERS da duoc tao.';
GO


-- ------------------------------------------------------------
-- Bang ORDER_DETAILS: Chi tiet don hang
-- Total la cot tinh toan tu dong (Qty * UnitPrice)
-- ------------------------------------------------------------
CREATE TABLE ORDER_DETAILS (
    OrderDetailID  INT            IDENTITY(1,1) NOT NULL,
    OrderID        INT                          NOT NULL,
    ProductID      INT                          NOT NULL,
    Qty            INT                          NOT NULL,
    UnitPrice      DECIMAL(18,2)                NOT NULL,
    Total          AS (Qty * UnitPrice)         PERSISTED,

    CONSTRAINT PK_ORDER_DETAILS         PRIMARY KEY (OrderDetailID),
    CONSTRAINT FK_ORDERDET_ORDERS       FOREIGN KEY (OrderID)
        REFERENCES ORDERS(OrderID)
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    CONSTRAINT FK_ORDERDET_PRODUCTS     FOREIGN KEY (ProductID)
        REFERENCES PRODUCTS(ProductID)
        ON UPDATE CASCADE
        ON DELETE NO ACTION,
    CONSTRAINT CHK_ORDERDET_Qty         CHECK (Qty > 0),
    CONSTRAINT CHK_ORDERDET_UnitPrice   CHECK (UnitPrice >= 0),
    CONSTRAINT UQ_ORDERDET_Order_Prod   UNIQUE (OrderID, ProductID)
);
GO

PRINT '>>> Bang ORDER_DETAILS da duoc tao.';
GO


-- ============================================================
-- 3. TAO INDEX HO TRO TIM KIEM
-- ============================================================
CREATE INDEX IX_PRODUCTS_CategoryID  ON PRODUCTS      (CategoryID);
CREATE INDEX IX_ORDERS_CustomerID    ON ORDERS        (CustomerID);
CREATE INDEX IX_ORDERS_OrderDate     ON ORDERS        (OrderDate);
CREATE INDEX IX_ORDERDET_OrderID     ON ORDER_DETAILS (OrderID);
CREATE INDEX IX_ORDERDET_ProductID   ON ORDER_DETAILS (ProductID);
GO

PRINT '>>> Cac INDEX da duoc tao.';
GO


-- ============================================================
-- 4. THEM DU LIEU MAU
-- ============================================================

-- ------------------------------------------------------------
-- Du lieu mau: USERS (5 tai khoan)
-- ------------------------------------------------------------
INSERT INTO USERS (UserName, FullName, Password, Phone) VALUES
    ('admin',      N'Nguyen Van An',    'Admin@123',   '0901234567'),
    ('manager01',  N'Tran Thi Bich',    'Manager@456', '0912345678'),
    ('staff01',    N'Le Van Cuong',     'Staff@789',   '0923456789'),
    ('staff02',    N'Pham Thi Dung',    'Staff@012',   '0934567890'),
    ('warehouse1', N'Hoang Minh Tuan',  'Ware@345',    '0945678901');
GO
PRINT '>>> Du lieu mau USERS: 5 ban ghi.';
GO


-- ------------------------------------------------------------
-- Du lieu mau: CATEGORIES (6 danh muc)
-- ------------------------------------------------------------
INSERT INTO CATEGORIES (Name) VALUES
    (N'Thiet bi dien tu'),
    (N'Van phong pham'),
    (N'Thiet bi van phong'),
    (N'Do gia dung'),
    (N'Linh kien may tinh'),
    (N'Phu kien di dong');
GO
PRINT '>>> Du lieu mau CATEGORIES: 6 ban ghi.';
GO


-- ------------------------------------------------------------
-- Du lieu mau: PRODUCTS (12 san pham)
-- ------------------------------------------------------------
INSERT INTO PRODUCTS (Name, Quantity, Description, CategoryID) VALUES
    (N'Man hinh LCD 24 inch',       50,  N'Man hinh full HD 1920x1080, tan so 75Hz',     1),
    (N'Ban phim co RGB',            120, N'Ban phim co switches blue, co den RGB',        1),
    (N'Chuot gaming 6400 DPI',      200, N'Chuot co day, 6 nut, co den LED',              1),
    (N'But bi xanh Thien Long',     500, N'But bi muc xanh, dau 0.7mm, hop 12 cai',      2),
    (N'Tap 200 trang A4',           800, N'Tap hoc sinh 200 trang, khong dong',           2),
    (N'Giay A4 IK Plus 70gsm',      300, N'Giay in A4, 70gsm, ream 500 to',              2),
    (N'May in HP LaserJet 107a',    15,  N'May in laser trang den, toc do 20 trang/phut', 3),
    (N'May scan Epson DS-310',      8,   N'May scan 2 mat tu dong, toc do 25 trang/phut', 3),
    (N'Noi com dien Sunhouse 1.8L', 75,  N'Noi com dien 1.8 lit, chong dinh, giu am',    4),
    (N'Quat dung Panasonic F-302',  40,  N'Quat dung 3 cap toc do, canh 3 la',           4),
    (N'RAM DDR4 8GB 3200MHz',       150, N'RAM laptop/PC DDR4, bus 3200MHz',              5),
    (N'Op lung iPhone 15 Pro',      250, N'Op lung chong soc Silicon, nhieu mau',         6);
GO
PRINT '>>> Du lieu mau PRODUCTS: 12 ban ghi.';
GO


-- ------------------------------------------------------------
-- Du lieu mau: CUSTOMERS (6 khach hang)
-- ------------------------------------------------------------
INSERT INTO CUSTOMERS (Name) VALUES
    (N'Cong ty TNHH ABC Technology'),
    (N'Truong THPT Nguyen Du'),
    (N'Van phong Luat su Minh Duc'),
    (N'Sieu thi Co-opmart Quan 7'),
    (N'Nguyen Thanh Long'),
    (N'Tran Thi Mai Huong');
GO
PRINT '>>> Du lieu mau CUSTOMERS: 6 ban ghi.';
GO


-- ------------------------------------------------------------
-- Du lieu mau: ORDERS (8 don hang)
-- ------------------------------------------------------------
INSERT INTO ORDERS (CustomerID, OrderDate) VALUES
    (1, '2025-01-05'),
    (2, '2025-01-10'),
    (1, '2025-01-20'),
    (3, '2025-02-03'),
    (4, '2025-02-14'),
    (5, '2025-03-01'),
    (2, '2025-03-15'),
    (6, '2025-03-18');
GO
PRINT '>>> Du lieu mau ORDERS: 8 ban ghi.';
GO


-- ------------------------------------------------------------
-- Du lieu mau: ORDER_DETAILS (16 dong chi tiet)
-- ------------------------------------------------------------
INSERT INTO ORDER_DETAILS (OrderID, ProductID, Qty, UnitPrice) VALUES
    -- Don hang 1 - Cong ty ABC Technology
    (1, 1, 5,  3500000),   -- Man hinh LCD x5
    (1, 2, 10,  850000),   -- Ban phim co x10
    (1, 3, 10,  650000),   -- Chuot gaming x10

    -- Don hang 2 - Truong THPT Nguyen Du
    (2, 4, 100,  35000),   -- But bi x100
    (2, 5, 200,  15000),   -- Tap viet x200
    (2, 6,  20,  85000),   -- Giay A4 x20

    -- Don hang 3 - Cong ty ABC (lan 2)
    (3, 7,  2, 3200000),   -- May in x2
    (3, 8,  1, 8500000),   -- May scan x1

    -- Don hang 4 - Van phong Luat su
    (4, 6, 10,  85000),    -- Giay A4 x10
    (4, 2,  3,  850000),   -- Ban phim co x3

    -- Don hang 5 - Co-opmart
    (5,  9, 20,  650000),  -- Noi com dien x20
    (5, 10, 15,  420000),  -- Quat dung x15

    -- Don hang 6 - Nguyen Thanh Long
    (6, 11, 2, 1200000),   -- RAM DDR4 x2
    (6, 12, 1,   250000),  -- Op lung x1

    -- Don hang 7 - Truong THPT (lan 2)
    (7, 5, 100, 15000),    -- Tap viet x100

    -- Don hang 8 - Tran Thi Mai Huong
    (8, 12, 2,  250000);   -- Op lung x2
GO
PRINT '>>> Du lieu mau ORDER_DETAILS: 16 ban ghi.';
GO


-- ============================================================
-- 5. TAO VIEW HO TRO GIAO DIEN
-- ============================================================

-- View: San pham kem ten danh muc (dung cho man hinh Product)
CREATE VIEW vw_Products_WithCategory AS
    SELECT
        p.ProductID,
        p.Name        AS ProductName,
        p.Quantity,
        p.Description,
        c.CategoryID,
        c.Name        AS CategoryName
    FROM PRODUCTS p
    INNER JOIN CATEGORIES c ON p.CategoryID = c.CategoryID;
GO

-- View: Tong hop don hang kem ten khach hang (dung cho man hinh Orders)
CREATE VIEW vw_Orders_Summary AS
    SELECT
        o.OrderID,
        o.OrderDate,
        cu.CustomerID,
        cu.Name                    AS CustomerName,
        COUNT(od.OrderDetailID)    AS TotalItems,
        ISNULL(SUM(od.Total), 0)   AS GrandTotal
    FROM ORDERS o
    INNER JOIN CUSTOMERS     cu ON o.CustomerID = cu.CustomerID
    LEFT  JOIN ORDER_DETAILS od ON o.OrderID    = od.OrderID
    GROUP BY o.OrderID, o.OrderDate, cu.CustomerID, cu.Name;
GO

-- View: Chi tiet don hang kem ten san pham va danh muc
CREATE VIEW vw_OrderDetails_Full AS
    SELECT
        od.OrderDetailID,
        od.OrderID,
        od.Qty,
        od.UnitPrice,
        od.Total,
        p.ProductID,
        p.Name   AS ProductName,
        p.Description,
        c.Name   AS CategoryName
    FROM ORDER_DETAILS od
    INNER JOIN PRODUCTS   p ON od.ProductID = p.ProductID
    INNER JOIN CATEGORIES c ON p.CategoryID = c.CategoryID;
GO

PRINT '>>> Cac VIEW da duoc tao.';
GO


-- ============================================================
-- 6. TAO STORED PROCEDURES
-- ============================================================

-- SP: Tim kiem san pham theo ten hoac danh muc
CREATE PROCEDURE sp_SearchProducts
    @Keyword    NVARCHAR(100) = NULL,
    @CategoryID INT           = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        p.ProductID,
        p.Name AS ProductName,
        p.Quantity,
        p.Description,
        c.Name AS CategoryName
    FROM PRODUCTS p
    INNER JOIN CATEGORIES c ON p.CategoryID = c.CategoryID
    WHERE
        (@Keyword    IS NULL OR p.Name LIKE N'%' + @Keyword + '%')
        AND
        (@CategoryID IS NULL OR p.CategoryID = @CategoryID)
    ORDER BY p.Name;
END;
GO


-- SP: Tao don hang moi, tra ve OrderID vua tao
CREATE PROCEDURE sp_CreateOrder
    @CustomerID INT,
    @OrderDate  DATE = NULL,
    @NewOrderID INT  OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF @OrderDate IS NULL
        SET @OrderDate = CAST(GETDATE() AS DATE);

    INSERT INTO ORDERS (CustomerID, OrderDate)
    VALUES (@CustomerID, @OrderDate);

    SET @NewOrderID = SCOPE_IDENTITY();
END;
GO


-- SP: Them san pham vao don hang, dong thoi giam ton kho
CREATE PROCEDURE sp_AddOrderDetail
    @OrderID   INT,
    @ProductID INT,
    @Qty       INT,
    @UnitPrice DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Kiem tra ton kho du khong
        IF (SELECT Quantity FROM PRODUCTS WHERE ProductID = @ProductID) < @Qty
        BEGIN
            RAISERROR(N'Ton kho khong du so luong yeu cau.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Them chi tiet don hang
        INSERT INTO ORDER_DETAILS (OrderID, ProductID, Qty, UnitPrice)
        VALUES (@OrderID, @ProductID, @Qty, @UnitPrice);

        -- Tru ton kho
        UPDATE PRODUCTS
        SET    Quantity = Quantity - @Qty
        WHERE  ProductID = @ProductID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

PRINT '>>> Cac STORED PROCEDURE da duoc tao.';
GO


-- ============================================================
-- 7. KIEM TRA TONG KET
-- ============================================================
PRINT '';
PRINT '=== TONG SO BAN GHI TUNG BANG ===';

SELECT [Bang], [So ban ghi] FROM (
    SELECT 'USERS'         AS [Bang], COUNT(*) AS [So ban ghi] FROM USERS         UNION ALL
    SELECT 'CATEGORIES',               COUNT(*)               FROM CATEGORIES     UNION ALL
    SELECT 'PRODUCTS',                 COUNT(*)               FROM PRODUCTS       UNION ALL
    SELECT 'CUSTOMERS',                COUNT(*)               FROM CUSTOMERS      UNION ALL
    SELECT 'ORDERS',                   COUNT(*)               FROM ORDERS         UNION ALL
    SELECT 'ORDER_DETAILS',            COUNT(*)               FROM ORDER_DETAILS
) AS Summary;
GO

PRINT '';
PRINT '=== DEMO: Danh sach san pham kem danh muc ===';
SELECT ProductID, ProductName, Quantity, CategoryName
FROM   vw_Products_WithCategory
ORDER  BY CategoryName, ProductName;
GO

PRINT '';
PRINT '=== DEMO: Tong hop don hang ===';
SELECT OrderID, CustomerName, OrderDate, TotalItems, GrandTotal
FROM   vw_Orders_Summary
ORDER  BY OrderDate DESC;
GO

PRINT '';
PRINT '=== DEMO: San pham sap het hang (Quantity < 20) ===';
SELECT ProductID, Name AS ProductName, Quantity
FROM   PRODUCTS
WHERE  Quantity < 20
ORDER  BY Quantity ASC;
GO

PRINT '';
PRINT '============================================================';
PRINT ' HOAN THANH! StockFlowDb san sang su dung.';
PRINT '============================================================';
GO
