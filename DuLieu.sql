create database QL_SANBONG
go
use QL_SANBONG
go
create table Users
(
	Email char(100)not null primary key,
	HoTen nvarchar(30),
	SDT char(12),
	DiaChi nvarchar(50),
	MatKhau Char(30),
	IsAdmin int DEFAULT 0
)
go

create table LoaiSan
(
	MaLoai char(10)not null primary key,
	TenLoaiSan nvarchar(30),
)
go
create table San
(
	MaSan char(10)not null primary key,
	TenSan nvarchar(30),
	MaLoai char(10),
	GiaThue float
)
create table KhachHang
(
	SDT char(12)not null primary key,
	TenKhachHang nvarchar(30),
)
go
create table DatSan
(
	MaDatSan int not null primary key identity (1,1),
	SDTKhachHang char(12),
	MaSan char(10),
	NgayDat Date,
	TGVao Time,
	TGRa Time,
)
go
create table HoaDon
(
	MaHoaDon int not null primary key identity (1,1),
	MaDatSan int,
	EmailUser char(100),
	TongTien int,
)
go


--Tao Khoa Ngoai--

alter table San
add CONSTRAINT FK_MaLoai_San_LoaiSan FOREIGN KEY(MaLoai) REFERENCES LoaiSan(MaLoai)

alter table DatSan
add CONSTRAINT FK_SDT_DatSan_KhachHang FOREIGN KEY(SDTKhachHang) REFERENCES KhachHang(SDT)

alter table DatSan
add CONSTRAINT FK_MaSan_DatSan_San FOREIGN KEY(MaSan) REFERENCES San(MaSan)

alter table HoaDon
add CONSTRAINT FK_MaDatSan_HoaDon_DatSan FOREIGN KEY(MaDatSan) REFERENCES DatSan(MaDatSan)

alter table HoaDon
add CONSTRAINT FK_Email_HoaDon_Users FOREIGN KEY(EmailUser) REFERENCES Users(Email)

--Them Du lieu--
insert into LoaiSan
Values('L01',N'Sân 5'),
('L02',N'Sân 7'),
('L03',N'Sân 11')
go

insert into San
Values('SAN07',N'Sân 7 Bình Dương','L02',100000),
('SAN02',N'Sân 7 BÌNH CHÁNH','L02',200000),
('SAN03',N'Sân 11 HÓC MÔN','L03',500000),
('SAN04',N'Sân 5 LONG AN','L01',150000),
('SAN05',N'Sân 5 HUFI','L01',550000),
('SAN06',N'Sân 11 Mỹ Đình','L03',1150000)

go



insert into Users(Email,HoTen,SDT,DiaChi,MatKhau)
Values('admin@gmail.com',N'Văn Hữu Thành Tài','0981208297',N'140 lê trọng tấn','123'),
('haunv@gmail.com',N'Nguyễn Văn Hậu','123546',N'Long An','123'),
('taint@gmail.com',N'Nguyễn Thành Tài','123546',N'Kien Giang','123'),
('nhatrq@gmail.com',N'Trần Quang Nhật','123546',N'TPHCM','123'),
('dungvh@gmail.com',N'Văn Hữu Dũng','123546',N'Quảng Nam','123')
go


insert into KhachHang
Values('0981208297',N'Mr Hải'),
('2001207133',N'Bầu Hiển'),
('16052002',N'Đội Tuyển Quốc Gia'),
('0987335490',N'Anh Em Nghệ sĩ'),
('0987165490',N'Công Ty Phương Trang')
go

set dateformat DMY
insert into DatSan
Values('2001207133','San03','2/9/2023','16:00:00','18:00:00'),
('0981208297','San07','30/12/2022','20:00:00','23:30:00'),
('16052002','San02','16/05/2022','19:00:00','21:30:00'),
('16052002','San03','21/12/2022','19:00:00','23:30:00')
go

update Users 
set IsAdmin = 1
where Email = 'admin@gmail.com'
go

 
--truyền vào ngày đặt TGVao TGRa trả về danh sách sân được phép đặt
CREATE PROCEDURE DS_San_duoc_dat @ngaydat date, @tgvao time, @tgra time
AS
BEGIN
	select * from San 
	where MaSan NOT IN (select San.MaSan 
						from San, DatSan
						where San.MaSan = DatSan.MaSan and 
						NgayDat = @ngaydat and ((TGVao between @tgvao and @tgra) or 
						(TGRa between @tgvao and @tgra)or (TGVao < @tgvao and TGRa > @tgra)))
END;

exec DS_San_duoc_dat '30/12/2022', '19:00:00', '21:00:00'

--truyền vào ngày đặt TGVao TGRa trả về danh sách sân bị trùng
 CREATE PROCEDURE DS_San_trung_gio @ngaydat date, @tgvao time, @tgra time
AS
BEGIN
	select DatSan.*, KhachHang.TenKhachHang 
	from DatSan, KhachHang 
	where DatSan.SDTKhachHang = KhachHang.SDT and NgayDat = @ngaydat and 
	((TGVao between @tgvao and @tgra) or (TGRa between @tgvao and @tgra) or 
	(TGVao < @tgvao and TGRa > @tgra))
END;

exec DS_San_trung_gio '30/12/2022', '19:00:00', '21:00:00'

--truyền vào sdt khách hàng tính ra được doanh thu theo khách hàng đó
CREATE PROC SP_DoanhThuKhachHang @sdt char(20)
AS
BEGIN	
	IF NOT EXISTS(SELECT * FROM KhachHang WHERE SDT=@sdt)
		PRINT'KHONG CO KHACH HANG NAY'
	ELSE
		BEGIN
			select convert (money,sum(TongTien))as'Tien' from  DatSan ds,HoaDon hd  where ds.MaDatSan=hd.MaDatSan and ds.SDTKhachHang=@sdt			
		END
END
EXEC SP_DoanhThuKhachHang '2001207133'
DROP PROC SP_DoanhThuKhachHang
--truyền vô email user trả về doanh thu theo email user đó
CREATE PROC SP_DoanhThuTheoEmail @email char(20)
AS
BEGIN	
	IF NOT EXISTS(SELECT * FROM Users WHERE Email=@email)
		PRINT'KHONG CO USER NAY'
	ELSE
		BEGIN
				select convert (money,sum(TongTien))as'Tien' from HoaDon where EmailUser=@email			
		END
END
EXEC SP_DoanhThuTheoEmail 'admin@gmail.com'
--truyền vô mã sân tính ra dược doanh thu của sân đó
CREATE PROC SP_DoanhThuSan @masan char(20)
AS
BEGIN	
	IF NOT EXISTS(SELECT * FROM San WHERE MaSan=@masan)
		PRINT'KHONG CO San NAY'
	ELSE
		BEGIN
				select convert (money,sum(TongTien))as'Tien' from  DatSan ds,HoaDon hd  where ds.MaDatSan=hd.MaDatSan and ds.MaSan=@masan
				
		END
END
EXEC SP_DoanhThuSan 'San02'
DROP PROC SP_DoanhThuSan

--truyền vào mã sân trả về bảng thời gian đá của sân đó trong hôm nay
 CREATE PROCEDURE Thoi_gian_da_hom_nay @masan char(10)
AS
BEGIN
	select *  , CONCAT(TGVao,' Toi ', TGRa) as 'Thoi Gian Da'from San,DatSan where san.MaSan=DatSan.MaSan and datsan.MaSan=@masan and NgayDat=CONVERT(date,GETDATE())
END;
delete DatSan where MaDatSan=1012
exec Thoi_gian_da_hom_nay 'San02'
drop proc Thoi_gian_da_hom_nay
select * from dbo.HoaDon
go
create function F_TraVeSanDaDat_Trung(@Ngay Date, @TGVao time, @TGRa Time)
returns table
as 
return (select DatSan.*, KhachHang.TenKhachHang from DatSan, KhachHang where DatSan.SDTKhachHang = KhachHang.SDT and NgayDat = @Ngay and ((TGVao between @TGVao and @TGRa) or (TGRa between @TGVao and @TGRa) or (TGVao < @TGVao and TGRa >@TGRa )))
go
select * from DatSan where NgayDat='2022-12-30'
select * from F_TraVeSanDaDat_Trung('2022-12-30','22:00:00','23:00:00')
drop function F_TraVeSanDaDat_Trung
go
create function F_DanhSachDatSanHomNay()
returns table
as 
return (select KhachHang.TenKhachHang,San.TenSan,DatSan.*, GETDATE() as 'now' from DatSan,KhachHang,San where DatSan.SDTKhachHang=KhachHang.SDT and san.MaSan=DatSan.MaSan and NgayDat=CONVERT(date,GETDATE()))
go


select * from San
select * from DatSan

select * from Users
where Email = 'admin@gmail.com' and IsAdmin = 1
