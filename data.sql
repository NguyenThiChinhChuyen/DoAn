USE [DuLieuDoAn]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CreateMaHD]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Xây dựng hàm phát sinh mã phiếu đặt báo có dạng "PH001"
create function [dbo].[fn_CreateMaHD]()
	returns nvarchar(50)
begin
		
		declare @MaHDOld varchar(50), @MaHDNew nvarchar(50)
		select Top 1 @MaHDOld=SoHD from HOADON order by SoHD Desc
		Return 'H' + format(right(@MaHDOld,3)+1,'00#')
end

GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[SoHD] [nvarchar](50) NOT NULL,
	[NgayHD] [date] NULL,
	[MaKH] [nvarchar](50) NULL,
	[MaNV] [nvarchar](50) NULL,
	[NoiDung] [nvarchar](512) NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOADON_CT]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON_CT](
	[SoHDCT] [nvarchar](50) NOT NULL,
	[SoHD] [nvarchar](50) NULL,
	[MaSP] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_HOADON_CT] PRIMARY KEY CLUSTERED 
(
	[SoHDCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOADONDH_CT]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADONDH_CT](
	[SoHDDH] [nvarchar](50) NOT NULL,
	[MaSP] [nvarchar](50) NULL,
	[NgayHDDH] [datetime2](7) NULL,
	[NgayGH] [date] NULL,
	[TenKHGH] [nvarchar](50) NULL,
	[DiaChiGH] [nvarchar](50) NULL,
	[SDTGH] [nchar](10) NULL,
	[MaNV] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_HOADONDH_CT_1] PRIMARY KEY CLUSTERED 
(
	[SoHDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [nvarchar](50) NOT NULL,
	[TenKH] [nvarchar](128) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](512) NULL,
	[SDT] [varchar](12) NULL CONSTRAINT [DF_KHACHHANG_SDT]  DEFAULT ((10)),
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAITK]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITK](
	[MaLTK] [int] NOT NULL,
	[TenLTK] [nvarchar](30) NULL,
 CONSTRAINT [PK_LOAITK] PRIMARY KEY CLUSTERED 
(
	[MaLTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NCC]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCC](
	[MaNCC] [nvarchar](50) NOT NULL,
	[TenNCC] [nvarchar](128) NOT NULL,
	[DiaChi] [nvarchar](512) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_NCC] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](128) NOT NULL,
	[DiaChi] [nvarchar](512) NOT NULL,
	[SDT] [varchar](12) NULL CONSTRAINT [DF_NHANVIEN_SDT]  DEFAULT ((10)),
	[Email] [nvarchar](30) NULL,
	[ChucVu] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[MaLTK] [int] NOT NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[SoPhieuNhap] [nvarchar](50) NOT NULL,
	[NgayPhieuNhap] [date] NULL,
	[NoiDung] [nvarchar](128) NULL,
	[MaNV] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[SoPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUNHAP_CT]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP_CT](
	[SoPhieuNhapCT] [nvarchar](50) NOT NULL,
	[SoPhieuNhap] [nvarchar](50) NOT NULL,
	[MaSP] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[ThanhTien] [int] NULL,
	[MaNCC] [nvarchar](50) NULL,
	[NgayPhieuNhap] [date] NULL,
 CONSTRAINT [PK_PHIEUNHAP_CT] PRIMARY KEY CLUSTERED 
(
	[SoPhieuNhapCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUXUAT]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUXUAT](
	[SoPhieuXuat] [nvarchar](50) NOT NULL,
	[NgayPhieuXuat] [date] NULL,
	[NoiDung] [nvarchar](128) NULL,
	[MaNV] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHIEUXUAT] PRIMARY KEY CLUSTERED 
(
	[SoPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUXUAT_CT]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUXUAT_CT](
	[SoPhieuXuatCT] [nvarchar](50) NOT NULL,
	[SoPhieuXuat] [nvarchar](50) NOT NULL,
	[MaSP] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_PHIEUXUAT_CT] PRIMARY KEY CLUSTERED 
(
	[SoPhieuXuatCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MaSP] [nvarchar](50) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[NgaySX] [date] NULL,
	[NoiSX] [nvarchar](128) NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
	[SoLuong] [int] NULL,
	[GiaGoc] [float] NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[HOADON] ([SoHD], [NgayHD], [MaKH], [MaNV], [NoiDung]) VALUES (N'H1', CAST(N'2020-06-20' AS Date), N'K1', N'NV1', N'Mua lẻ')
INSERT [dbo].[HOADON] ([SoHD], [NgayHD], [MaKH], [MaNV], [NoiDung]) VALUES (N'H2', CAST(N'2020-06-30' AS Date), N'K2', N'NV3', N'Mua lẻ')
INSERT [dbo].[HOADON] ([SoHD], [NgayHD], [MaKH], [MaNV], [NoiDung]) VALUES (N'H3', CAST(N'2020-07-30' AS Date), N'K3', N'NV2', N'Mua lẻ')
INSERT [dbo].[HOADON_CT] ([SoHDCT], [SoHD], [MaSP], [SoLuong], [ThanhTien]) VALUES (N'CT1       ', N'H1        ', N'S3        ', 12, 120000)
INSERT [dbo].[HOADON_CT] ([SoHDCT], [SoHD], [MaSP], [SoLuong], [ThanhTien]) VALUES (N'CT2       ', N'H2        ', N'S1        ', 1, 30000)
INSERT [dbo].[HOADON_CT] ([SoHDCT], [SoHD], [MaSP], [SoLuong], [ThanhTien]) VALUES (N'CT3', N'H3', N'S2', 5, 50000)
INSERT [dbo].[HOADON_CT] ([SoHDCT], [SoHD], [MaSP], [SoLuong], [ThanhTien]) VALUES (N'CT4', N'H2', N'S2', 7, 70000)
INSERT [dbo].[HOADONDH_CT] ([SoHDDH], [MaSP], [NgayHDDH], [NgayGH], [TenKHGH], [DiaChiGH], [SDTGH], [MaNV], [SoLuong], [ThanhTien], [TinhTrang]) VALUES (N'H001', N'S1', CAST(N'2020-08-05 00:00:00.0000000' AS DateTime2), CAST(N'2020-08-04' AS Date), N'Toàn', N'Hưng Hòa', N'0389842453', N'NV1', 5, 150000, 0)
INSERT [dbo].[HOADONDH_CT] ([SoHDDH], [MaSP], [NgayHDDH], [NgayGH], [TenKHGH], [DiaChiGH], [SDTGH], [MaNV], [SoLuong], [ThanhTien], [TinhTrang]) VALUES (N'H002', N'S3', CAST(N'2020-08-05 00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, N'NV1', 5, 50000, 0)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GioiTinh], [DiaChi], [SDT]) VALUES (N'K1', N'Lưu', N'Nam', N'Bình Dương', N'0363517354')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GioiTinh], [DiaChi], [SDT]) VALUES (N'K2', N'Phúc', N'Nam', N'Bình Dương', N'0365328487')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GioiTinh], [DiaChi], [SDT]) VALUES (N'K3', N'Oanh', N'Nữ', N'Phú Giáo', N'0374794387')
INSERT [dbo].[LOAITK] ([MaLTK], [TenLTK]) VALUES (1, N'Quản Lý')
INSERT [dbo].[LOAITK] ([MaLTK], [TenLTK]) VALUES (2, N'Thủ Kho')
INSERT [dbo].[LOAITK] ([MaLTK], [TenLTK]) VALUES (3, N'Nhân Viên Bán Hàng')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A1        ', N'TĐ Nước Giải Khát Tân Hiệp Phát', N'Thuận An - Bình Dương', N'0274123456', N'tanhiepphat@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A10       ', N'CT TNHH Johnson&Johnson Việt Nam ', N'Tp Hồ Chí Minh', N'0278916452', N'johnson@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A11       ', N'CT TNHH Nhà Máy Bia Việt Nam', N'Tp Hồ Chí Minh', N'0278143655', N'biaviet@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A12       ', N'CT Ajinomoto Việt Nam', N'Tp Hồ Chí Minh', N'0278355752', N'ajinomoto@gmail.com ')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A13       ', N'CTCP AceCook Việt Nam', N'Dĩ An - Bình Dương', N'0274658254', N'acecook@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A14       ', N'TĐ CASUCO Cần Thơ', N'Vị Thanh - Hậu Giang', N'0293642447', N'casuco@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A15       ', N'CT Tâm ', N'Bến Tre', N'0275635295', N'tamduc@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A2        ', N'TĐ PepsiCo Việt Nam', N'Tp Hồ Chí Minh', N'0278746254', N'pepsi@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A3        ', N'Tổng CTY CocaCola Việt Nam', N'Bình Dương', N'0274647828', N'cocacola@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A4        ', N'TĐ Anheuser-Busch InBev ', N'Tp Hồ Chí Minh ', N'0278536174', N'inbev@gmail.com ')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A5        ', N'TĐ P&G', N'Bình Dương ', N'0274816472', N'pg@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A6        ', N'TĐ Unilever', N'Tp Hồ Chí Minh', N'0278563816', N'unilever@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A7        ', N'CTCP Dầu Thực Vật Trường An', N'Tp Hồ Chí Minh', N'0278658355', N'truongan@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A8        ', N'CTCP Hàng Tiêu Dùng Masan', N'Tp Hồ Chí Minh', N'0278657246', N'masan@gmail.com')
INSERT [dbo].[NCC] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'A9        ', N'CTCP Nhựa Duy Tân ', N'Tp Hồ Chí Minh', N'0278658254', N'duytan@gmail.com')
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [DiaChi], [SDT], [Email], [ChucVu], [UserName], [Password], [MaLTK]) VALUES (N'NV1       ', N'Nguyễn Thị Quỳnh', N'Thủ Dầu Một, Bình Dương', N'345678910', N'quynh@gmail.com', N'Nhân Viên', N'nvquynh', N'123', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [DiaChi], [SDT], [Email], [ChucVu], [UserName], [Password], [MaLTK]) VALUES (N'NV2       ', N'Lê Thị Hằng', N'Bàu Bàng, Bình Dương', N'312345678', N'hang@gmail.com', N'Nhân Viên', N'nhhang', N'123', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [DiaChi], [SDT], [Email], [ChucVu], [UserName], [Password], [MaLTK]) VALUES (N'NV3       ', N'Vũ Khánh Toàn', N'Thủ Dầu Một, Bình Dương', N'785123456', N'toan@gmail.com', N'Thủ Kho', N'nhthukho', N'123', 2)
INSERT [dbo].[NHANVIEN] ([MaNV], [HoTen], [DiaChi], [SDT], [Email], [ChucVu], [UserName], [Password], [MaLTK]) VALUES (N'NV4       ', N'Trần Hồng Châu', N'Quận 2, Thành Phố Hồ Chí Minh', N'812345678', N'chau@gmail.com', N'Quản Lý', N'admin', N'123', 1)
INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayPhieuNhap], [NoiDung], [MaNV]) VALUES (N'PN1       ', CAST(N'2020-04-20' AS Date), N'Nhập hàng Dầu ĂN', N'NV3       ')
INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayPhieuNhap], [NoiDung], [MaNV]) VALUES (N'PN2       ', CAST(N'2020-04-29' AS Date), N'Nhập Đường', N'NV4       ')
INSERT [dbo].[PHIEUNHAP_CT] ([SoPhieuNhapCT], [SoPhieuNhap], [MaSP], [SoLuong], [DonGia], [ThanhTien], [MaNCC], [NgayPhieuNhap]) VALUES (N'NCT1      ', N'PN1       ', N'S1        ', 50, 20000, 10000000, N'A7', CAST(N'2020-04-20' AS Date))
INSERT [dbo].[PHIEUNHAP_CT] ([SoPhieuNhapCT], [SoPhieuNhap], [MaSP], [SoLuong], [DonGia], [ThanhTien], [MaNCC], [NgayPhieuNhap]) VALUES (N'NCT2      ', N'PN2       ', N'S4        ', 50, 15000, 750000, N'A14', CAST(N'2020-04-29' AS Date))
INSERT [dbo].[PHIEUXUAT] ([SoPhieuXuat], [NgayPhieuXuat], [NoiDung], [MaNV]) VALUES (N'PX1       ', CAST(N'2020-07-01' AS Date), N'Xuất Sỉ', N'NV3       ')
INSERT [dbo].[PHIEUXUAT] ([SoPhieuXuat], [NgayPhieuXuat], [NoiDung], [MaNV]) VALUES (N'PX2       ', CAST(N'2020-06-30' AS Date), N'Xuất Sỉ', N'NV4       ')
INSERT [dbo].[PHIEUXUAT_CT] ([SoPhieuXuatCT], [SoPhieuXuat], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'XCT1      ', N'PX1       ', N'S3        ', 48, 7000, 336000)
INSERT [dbo].[PHIEUXUAT_CT] ([SoPhieuXuatCT], [SoPhieuXuat], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'XCT2      ', N'PX2       ', N'S2        ', 50, 7000, 350000)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [NgaySX], [NoiSX], [DonViTinh], [DonGia], [SoLuong], [GiaGoc]) VALUES (N'S1        ', N'Dầu Ăn Trường An', CAST(N'2019-04-29' AS Date), N'Tp HCM', N'Chai      ', 30000, 49, 28000)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [NgaySX], [NoiSX], [DonViTinh], [DonGia], [SoLuong], [GiaGoc]) VALUES (N'S2        ', N'Kẹo Mềm Sugus', CAST(N'2019-03-17' AS Date), N'Tp HCM', N'Bịch      ', 10000, 32, 8000)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [NgaySX], [NoiSX], [DonViTinh], [DonGia], [SoLuong], [GiaGoc]) VALUES (N'S3        ', N'Sữa Chua Ăn Vinamilk ', CAST(N'2020-01-02' AS Date), N'Tp HCM', N'Hộp       ', 10000, 45, 8000)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [NgaySX], [NoiSX], [DonViTinh], [DonGia], [SoLuong], [GiaGoc]) VALUES (N'S4        ', N'Đường Tinh Luyện', CAST(N'2019-08-26' AS Date), N'Hậu Giang', N'Kilogam   ', 22000, 39, 20000)
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_KHACHHANG]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NHANVIEN]
GO
ALTER TABLE [dbo].[HOADON_CT]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_CT_HOADON] FOREIGN KEY([SoHD])
REFERENCES [dbo].[HOADON] ([SoHD])
GO
ALTER TABLE [dbo].[HOADON_CT] CHECK CONSTRAINT [FK_HOADON_CT_HOADON]
GO
ALTER TABLE [dbo].[HOADON_CT]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_CT_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[HOADON_CT] CHECK CONSTRAINT [FK_HOADON_CT_SANPHAM]
GO
ALTER TABLE [dbo].[HOADONDH_CT]  WITH CHECK ADD  CONSTRAINT [FK_HOADONDH_CT_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[HOADONDH_CT] CHECK CONSTRAINT [FK_HOADONDH_CT_NHANVIEN]
GO
ALTER TABLE [dbo].[HOADONDH_CT]  WITH CHECK ADD  CONSTRAINT [FK_HOADONDH_CT_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[HOADONDH_CT] CHECK CONSTRAINT [FK_HOADONDH_CT_SANPHAM]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_LOAITK1] FOREIGN KEY([MaLTK])
REFERENCES [dbo].[LOAITK] ([MaLTK])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_LOAITK1]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUNHAP_CT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_CT_NCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NCC] ([MaNCC])
GO
ALTER TABLE [dbo].[PHIEUNHAP_CT] CHECK CONSTRAINT [FK_PHIEUNHAP_CT_NCC]
GO
ALTER TABLE [dbo].[PHIEUNHAP_CT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_CT_PHIEUNHAP] FOREIGN KEY([SoPhieuNhap])
REFERENCES [dbo].[PHIEUNHAP] ([SoPhieuNhap])
GO
ALTER TABLE [dbo].[PHIEUNHAP_CT] CHECK CONSTRAINT [FK_PHIEUNHAP_CT_PHIEUNHAP]
GO
ALTER TABLE [dbo].[PHIEUNHAP_CT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_CT_SANPHAM1] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[PHIEUNHAP_CT] CHECK CONSTRAINT [FK_PHIEUNHAP_CT_SANPHAM1]
GO
ALTER TABLE [dbo].[PHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUXUAT_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUXUAT] CHECK CONSTRAINT [FK_PHIEUXUAT_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUXUAT_CT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUXUAT_CT_PHIEUXUAT] FOREIGN KEY([SoPhieuXuat])
REFERENCES [dbo].[PHIEUXUAT] ([SoPhieuXuat])
GO
ALTER TABLE [dbo].[PHIEUXUAT_CT] CHECK CONSTRAINT [FK_PHIEUXUAT_CT_PHIEUXUAT]
GO
ALTER TABLE [dbo].[PHIEUXUAT_CT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUXUAT_CT_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[PHIEUXUAT_CT] CHECK CONSTRAINT [FK_PHIEUXUAT_CT_SANPHAM]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [CK_DonGia_GiaGoc] CHECK  (([DonGia]>=[GiaGoc]))
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [CK_DonGia_GiaGoc]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [CK_SoLuong] CHECK  (([SoLuong]>=(0)))
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [CK_SoLuong]
GO
/****** Object:  StoredProcedure [dbo].[proc_CreateMaHD]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[proc_CreateMaHD]
	@SoHDNew nvarchar(10) output
as
		
		declare @SoHDOld nvarchar(50)
		select Top 1 @SoHDOld=SoHD from HOADON order by SoHD Desc
		set @SoHDNew = 'H' + format(right(@SoHDOld,4)+1,'000#')

GO
/****** Object:  StoredProcedure [dbo].[proc_CreateMaHDDH]    Script Date: 8/5/2020 5:43:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_CreateMaHDDH]
	@SoHDDHNew nvarchar(10) output
as
		
		declare @SoHDDHOld nvarchar(50)
		select Top 1 @SoHDDHOld=SoHDDH from HOADONDH order by SoHDDH Desc
		set @SoHDDHNew = 'H' + format(right(@SoHDDHOld,4)+1,'000#')

GO
