using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentLINQ
{
    // Định nghĩa lớp Student
    class Student
    {
        public int Id { get; set; }     // Mã số học sinh
        public string Name { get; set; } // Tên học sinh
        public int Age { get; set; }     // Tuổi học sinh
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách học sinh
            List<Student> students = new List<Student>()
            {
                new Student { Id = 1, Name = "An", Age = 16 },
                new Student { Id = 2, Name = "Binh", Age = 18 },
                new Student { Id = 3, Name = "Hoa", Age = 14 },
                new Student { Id = 4, Name = "Hiep", Age = 19 },
                new Student { Id = 5, Name = "Anh", Age = 17 }
            };

            // a. In toàn bộ danh sách
            Console.WriteLine("Danh sách học sinh:");
            foreach (var s in students)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

            // b. Học sinh tuổi từ 15 đến 18
            var tuoi1518 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            Console.WriteLine("\nHọc sinh có tuổi từ 15 đến 18:");
            foreach (var s in tuoi1518)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

            // c. Học sinh tên bắt đầu bằng "A"
            var tenA = students.Where(s => s.Name.StartsWith("A"));
            Console.WriteLine("\nHọc sinh có tên bắt đầu bằng 'A':");
            foreach (var s in tenA)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

            // d. Tổng tuổi của tất cả học sinh
            var tongTuoi = students.Sum(s => s.Age);
            Console.WriteLine($"\nTổng tuổi của tất cả học sinh: {tongTuoi}");

            // e. Học sinh có tuổi lớn nhất
            var maxAge = students.Max(s => s.Age);
            var hsLonNhat = students.Where(s => s.Age == maxAge);
            Console.WriteLine("\nHọc sinh có tuổi lớn nhất:");
            foreach (var s in hsLonNhat)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

            // f. Sắp xếp theo tuổi tăng dần
            var sapXep = students.OrderBy(s => s.Age);
            Console.WriteLine("\nDanh sách sau khi sắp xếp theo tuổi tăng dần:");
            foreach (var s in sapXep)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.SET NOCOUNT ON;
GO

----------------------------------------------------------------------
-- 1. TẠO DATABASE
----------------------------------------------------------------------

-- Đóng các kết nối đang mở để xoá DB an toàn
IF DB_ID('QLBANHANG') IS NOT NULL
BEGIN
    ALTER DATABASE QLBANHANG SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLBANHANG;
END
GO

CREATE DATABASE QLBANHANG;
GO

USE QLBANHANG;
GO


----------------------------------------------------------------------
-- 2. TẠO BẢNG VÀ RÀNG BUỘC
----------------------------------------------------------------------

-- 2.1. Bảng KHACHHANG
CREATE TABLE KHACHHANG (
    MAKH      VARCHAR(5)    PRIMARY KEY,
    TENKH     NVARCHAR(30)  NOT NULL,
    DIACHI    NVARCHAR(50),
    DT        VARCHAR(11),
    EMAIL     VARCHAR(30),

    CONSTRAINT CK_KHACHHANG_DT CHECK (LEN(DT) BETWEEN 8 AND 11)
);
GO


-- 2.2. Bảng VATTU
CREATE TABLE VATTU (
    MAVT      VARCHAR(5)    PRIMARY KEY,
    TENVT     NVARCHAR(30)  NOT NULL,
    DVT       NVARCHAR(20),
    GIAMUA    MONEY,
    SLTON     INT,

    CONSTRAINT CK_VATTU_GIAMUA CHECK (GIAMUA > 0),
    CONSTRAINT CK_VATTU_SLTON  CHECK (SLTON >= 0)
);
GO


-- 2.3. Bảng HOADON
CREATE TABLE HOADON (
    MAHD      VARCHAR(10)   PRIMARY KEY,
    NGAY      DATE,
    MAKH      VARCHAR(5),
    TONGTG    FLOAT,

    CONSTRAINT CK_HOADON_NGAY CHECK (NGAY <= GETDATE()),

    CONSTRAINT FK_HOADON_MAKH FOREIGN KEY (MAKH)
        REFERENCES KHACHHANG(MAKH)
);
GO


-- 2.4. Bảng CTHD
CREATE TABLE CTHD (
    MAHD      VARCHAR(10),
    MAVT      VARCHAR(5),
    SL        INT,
    KHUYENMAI FLOAT,
    GIABAN    FLOAT,

    CONSTRAINT PK_CTHD PRIMARY KEY (MAHD, MAVT),

    CONSTRAINT CK_CTHD_SL CHECK (SL > 0),

    CONSTRAINT FK_CTHD_MAHD FOREIGN KEY (MAHD)
        REFERENCES HOADON(MAHD),

    CONSTRAINT FK_CTHD_MAVT FOREIGN KEY (MAVT)
        REFERENCES VATTU(MAVT)
);
GO


----------------------------------------------------------------------
-- 3. NHẬP DỮ LIỆU MẪU
----------------------------------------------------------------------

-- 3.1. KHACHHANG
INSERT INTO KHACHHANG VALUES
('KH01', N'Nguyễn Thị Bé',    N'Tân Bình',    '38457895', 'bnt@yahoo.com'),
('KH02', N'Lê Hoàng Nam',     N'Bình Chánh',  '39878987', 'namlehoang@gmail.com'),
('KH03', N'Trần Thị Chiếu',   N'Tân Bình',    '38457895', NULL),
('KH04', N'Mai Thị Quế Anh',  N'Bình Chánh',  NULL,       NULL),
('KH05', N'Lê Văn Sáng',      N'Quận 10',     NULL,       'sanglv@hcm.vnn.vn'),
('KH06', N'Trần Hoàng',       N'Tân Bình',    '38457897', NULL);
GO


-- 3.2. VATTU
INSERT INTO VATTU VALUES
('VT01', N'Xi măng',    N'Bao',  50000,  5000),
('VT02', N'Cát',        N'Khối', 45000,  50000),
('VT03', N'Gạch ống',   N'Viên', 120,    800000),
('VT04', N'Gạch thẻ',   N'Viên', 110,    800000),
('VT05', N'Đá lớn',     N'Khối', 250000, 100000),
('VT06', N'Đá nhỏ',     N'Khối', 33000,  100000),
('VT07', N'Lam gió',    N'Cái',  15000,  50000);
GO


-- 3.3. HOADON (định dạng ngày YYYY-MM-DD tiêu chuẩn SQL Server)
INSERT INTO HOADON VALUES
('HD001', '2010-05-12', 'KH01', NULL),
('HD002', '2010-05-25', 'KH02', NULL),
('HD003', '2010-05-25', 'KH04', NULL),
('HD004', '2010-05-25', 'KH04', NULL),
('HD005', '2010-05-26', 'KH03', NULL),
('HD006', '2010-06-02', 'KH04', NULL),
('HD007', '2010-06-22', 'KH04', NULL),
('HD008', '2010-06-25', 'KH04', NULL),
('HD009', '2010-08-15', 'KH04', NULL),
('HD010', '2010-09-30', 'KH01', NULL);
GO


-- 3.4. CTHD
INSERT INTO CTHD VALUES
('HD001', 'VT05', 5,     0, 52000),
('HD001', 'VT03', 10,    0, 30000),
('HD002', 'VT03', 10000, 0, 150),
('HD003', 'VT02', 20,    0, 55000),
('HD004', 'VT03', 50000, 0, 150),
('HD004', 'VT04', 20000, 0, 120),
('HD005', 'VT05', 10,    0, 30000),
('HD005', 'VT06', 15,    0, 35000),
('HD005', 'VT07', 20,    0, 17000),
('HD006', 'VT04', 10000, 0, 120),
('HD007', 'VT04', 20000, 0, 125),
('HD008', 'VT01', 100,   0, 55000),
('HD008', 'VT02', 20,    0, 47000),
('HD009', 'VT02', 25,    0, 48000),
('HD010', 'VT01', 25,    0, 57000);
GO


----------------------------------------------------------------------
-- 4. TÍNH TỔNG GIÁ TRỊ HÓA ĐƠN
----------------------------------------------------------------------

UPDATE HOADON
SET TONGTG =
(
    SELECT SUM(CT.SL * CT.GIABAN * (1 - ISNULL(CT.KHUYENMAI, 0)))
    FROM CTHD AS CT
    WHERE CT.MAHD = HOADON.MAHD
)
WHERE EXISTS (SELECT 1 FROM CTHD WHERE CTHD.MAHD = HOADON.MAHD);
GO

