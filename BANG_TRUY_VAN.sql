--=============================================================CHÍ VỸ=============================================================
--trigger tu soluong va dongia ta tinh duoc tong gia hang cua mot loai laptop cua cong ty do
create TRIGGER tgg_thanhtien
ON HangHoa
AFTER INSERT, UPDATE AS
BEGIN
	UPDATE HangHoa
	SET ThanhTien = SoLuong*DonGia
	WHERE MaLapTop = HangHoa.MaLapTop
END
go

--trigger thanh tien bang nhapkho
ALTER TRIGGER tgg_thanhtien1 --(Da chinh sua can duyet)		--DONE		--chonay
ON NhapKho
AFTER INSERT, UPDATE AS
BEGIN

	declare @thue int, @ma varchar(20)
	select @thue= inserted.SoLuongNhap * inserted.DonGiaNhap ,@ma= inserted.MaLapTop
	from inserted
	--
	UPDATE NhapKho
	SET ThanhTien = SoLuongNhap*DonGiaNhap  , Thue = @thue*0.1
	where MaLapTop = @ma
END
go

--trigger thanhtien cho xuatkho
ALTER TRIGGER tgg_thanhtien2 --(Da chinh sua can duyet)		--DONE	--chonay
ON XuatKho
AFTER INSERT, UPDATE AS
BEGIN

	declare @thue int, @ma varchar(20)
	select @thue= inserted.SoLuongXuat * inserted.DonGiaXuat ,@ma= inserted.MaLapTop
	from inserted
	--
	UPDATE XuatKho
	SET ThanhTien = SoLuongXuat*DonGiaXuat  , Thue = @thue*0.1
	where MaLapTop = @ma
END
--
create trigger XuatKho_Thue on XuatKho
after insert,update
begin
	
end

--proc them nhapkho
ALTER PROCEDURE proc_insNhapKho(@malap varchar(20), @ten varchar(20), @ngay datetime, @soluong int, @dongia varchar(20), @maphieu varchar(20),@pic image)
AS
	begin tran
		--Insert into PhieuNhap (MaPhieuNhap, MaNhaCungCap) values(@maphieu,null)
		--Cap nhat Kho
		INSERT INTO NhapKho(MaLapTop, TenLapTop, NgayNhap, SoLuongNhap, DonGiaNhap, MaPhieu) VALUES (@malap, @ten, @ngay, @soluong, @dongia, @maphieu)
		--cập nhật thúe
		update NhapKho
		set Thue = ThanhTien *0.1
		where MaLapTop = @malap
		--Cap nhat ben hang hoa
		UPDATE HangHoa
		SET HinhAnh = @pic,TenLapTop = @ten, SoLuong = @soluong, DonGia = @dongia
		WHERE MaLapTop = @malap
	commit tran
	--end
exec proc_insNhapKho 'T460', 'thinkpadt460', '1-2-2021', 2, '300', 'N1'
go

--proc them xuatkho		--chonay
ALTER PROCEDURE proc_insXuatKho(@malap varchar(20), @ten varchar(20), @ngay datetime, @soluong int, @dongia varchar(20), @maphieu varchar(20),@pic image)
AS
	begin tran
	--	Insert into PhieuXuat (MaPhieuXuat, MaCuaHang) values(@maphieu,null)
	INSERT INTO XuatKho(MaLapTop, TenLapTop, NgayXuat, SoLuongXuat, DonGiaXuat, MaPhieuXuat) VALUES (@malap, @ten, @ngay, @soluong, @dongia, @maphieu)
	--cập nhật thúe
	update XuatKho
	set Thue = ThanhTien *0.1
	where MaLapTop = @malap

	--Cap nhat ben hang hoa
		UPDATE HangHoa
		SET HinhAnh=@pic, TenLapTop = @ten, SoLuong = @soluong, DonGia = @dongia
		WHERE MaLapTop = @malap
	commit tran  --
	
	--end

exec proc_insXuatKho 'AsX', 'thinkpadt460', '1-2-2021', 2, '300', 'X1'
go

--proc xoa nhapkho
create PROC proc_delNhapKho(@malap varchar(20), @maphieu varchar(20))
AS

DELETE NhapKho WHERE MaLapTop = @malap AND MaPhieu = @maphieu
go

EXEC proc_delNhapKho 'T460', 'N1'
go

--proc xoa xuatkho
create PROC proc_delXuatKho(@malap varchar(20), @maphieu varchar(20))
AS
DELETE XuatKho WHERE MaLapTop = @malap AND MaPhieuXuat = @maphieu
go

EXEC proc_delXuatKho 'T460', 'X1'
go

--proc sua nhapkho (Da chinh sua can duyet)		--DONE		--chonay
alter PROC proc_upNhapKho(@malap varchar(20), @ten varchar(20), @ngay datetime, @soluong int, @dongia varchar(20), @maphieu varchar(20),@pic image)
AS
	begin tran
		UPDATE NhapKho SET TenLapTop= @ten, NgayNhap = @ngay,SoLuongNhap = @soluong, DonGiaNhap = @dongia
		WHERE MaLapTop = @malap AND MaPhieu = @maphieu
		--cập nhật thúe
		update NhapKho
		set Thue = ThanhTien *0.1
		where MaLapTop = @malap
		--Cap nhat ben hang hoa
		UPDATE HangHoa
		SET HinhAnh = @pic,TenLapTop = @ten, SoLuong = @soluong, DonGia = @dongia
		WHERE MaLapTop = @malap
	commit tran
	--end
EXEC proc_upNhapKho 'T460', 'ThinkPadT460', '1-2-2021', 2, '300', 'N1'
go


--proc sua xuatkho (Da chinh sua can duyet)		--DONE		--chonay
alter PROC proc_upXuatKho(@malap varchar(20), @ten varchar(20), @ngay datetime, @soluong int, @dongia varchar(20), @maphieu varchar(20),@pic image)
AS
	begin tran 
		UPDATE XuatKho SET TenLapTop= @ten, NgayXuat = @ngay,SoLuongXuat = @soluong, DonGiaXuat = @dongia
		WHERE MaLapTop = @malap AND MaPhieuXuat = @maphieu
		--cap nhat thue ben xuat kho
		update XuatKho
		set Thue = ThanhTien *0.1
		where MaLapTop = @malap
		--Cap nhat ben hang hoa
		UPDATE HangHoa
		SET HinhAnh=@pic, TenLapTop = @ten, SoLuong = @soluong, DonGia = @dongia
		WHERE MaLapTop = @malap
	commit tran

	end

exec proc_upXuatKho 'T460', 'ThinkPadT460', '1-3-2021', 2, '300', 'X1'
go

--Lo roi de luon
create PROC proc_getXuatKho
AS SELECT * FROM XuatKho

exec proc_getXuatKho
go

--proc tim kiem theo ma va ten latop xuatkho
alter PROC proc_searXuatkho (@text varchar(50))
AS
SELECT * 
FROM HienXuatKho 
WHERE CONCAT([Mã Laptop], [Tên Laptop]) LIKE '%'+ @text +'%'

EXEC proc_searXuatkho 'T'
go

--proc tim kiem theo ma va ten latop nhapkho
alter PROC proc_searNhapkho (@text varchar(50))
AS
SELECT * 
FROM HienNhapKho
WHERE CONCAT( [Mã Laptop], [Tên Laptop]) LIKE '%'+ @text +'%'

EXEC proc_searNhapkho 'T'
SELECT @@VERSION
--Tuấn Bổ sung
create function LayHinhAnh(@MaLT varchar(20))
returns table as 
return
(
	select HinhAnh
	from HangHoa
	where MaLapTop = @MaLT
)
select *from LayHinhAnh('ASUS_X01')

--proc kiem tra nhapkho
alter PROC proc_checkNhapkho(@laptop VARCHAR(20))
AS
SELECT * FROM NhapKho 
WHERE MaLapTop = @laptop 

EXEC proc_checkNhapkho 'T460', 'N1'
GO

--proc kiem tra xuatkho
alter PROC proc_checkXuatkho(@laptop VARCHAR(20))
AS
SELECT * FROM XuatKho 
WHERE MaLapTop = @laptop 

EXEC proc_checkXuatkho 'T460', 'X2'
--=============================================================SANG=============================================================
--create VIEW danhmuchanghoa as
Select hh.MaLapTop as 'Mã Laptop' ,hh.TenLapTop as 'Tên Laptop', hh.SoLuong as'Số Lượng',hh.DonGia as 'Đơn Giá',nk.NgayNhap as 'Ngày Nhập',xk.NgayXuat 'Ngày Xuất'
From HangHoa hh,NhapKho nk, XuatKho xk
--=============================================================TUẤN=============================================================
-- phần giao diện hàng hóa
alter VIEW HienNhapKho
as
(
	select MaLapTop as 'Mã Laptop',TenLapTop as 'Tên Laptop', NgayNhap as 'Ngày', SoLuongNhap as 'Số Lượng',DonGiaNhap as 'Đơn Giá',ThanhTien as 'Thành Tiền',MaPhieu as 'Mã Phiếu' 
	from NhapKho
)
alter  VIEW HienXuatKho 
as
(
	select MaLapTop as 'Mã Laptop',TenLapTop as 'Tên Laptop', NgayXuat as 'Ngày', SoLuongXuat as 'Số Lượng',DonGiaXuat as 'Đơn Giá',ThanhTien as 'Thành Tiền',MaPhieuXuat as 'Mã Phiếu' 
	from XuatKho
)
--Search Nhập kho
create view SearchNhapKho
as
(
		select NhapKho.MaLaptop as 'Mã Laptop',NhapKho.TenLapTop as 'Tên Laptop',HangHoa.HinhAnh as 'Hình Ảnh', NhapKho.SoLuongNhap as 'Số Lượng',NhapKho.DonGiaNhap as 'Đơn Giá',NhapKho.ThanhTien as 'Thành Tiền',NhapKho.NgayNhap as 'Ngày',NhapKho.MaPhieu as 'Mã Phiếu'
		from NhapKho,HangHoa
		where NhapKho.MaLapTop = HangHoa.MaLapTop

)
select * from SearchNhapKho
--Search Xuất Kho
create view SearchXuatKho
as
(
	select XuatKho.MaLaptop as 'Mã Laptop' ,XuatKho.TenLapTop as 'Tên Laptop',HangHoa.HinhAnh as 'Hình Ảnh',XuatKho.SoLuongXuat as 'Số Lượng ', XuatKho.DonGiaXuat as 'Đơn Giá',XuatKho.ThanhTien as 'Thành Tiền',XuatKho.NgayXuat as 'Ngày', XuatKho.MaPhieuXuat as 'Mã Phiếu'
	from XuatKho,HangHoa
	where HangHoa.MaLapTop = XuatKho.MaLapTop 
)
select * from SearchXuatKho
--
create view SearchAll
as
(
	SELECT *
	FROM SearchXuatKho
 
	UNION ALL

	SELECT *
	FROM SearchNhapKho
)
create VIEW danhmuchanghoa
as
(
	select HangHoa.MaLaptop as 'Mã Laptop',HangHoa.TenLaptop as 'Tên Laptop',HangHoa.HinhAnh as 'Hình Ảnh',HangHoa.DonGia as 'Đơn Giá',HangHoa.SoLuong as 'Số Lượng',HangHoa.ThanhTien as 'Thành Tiền',Xuat.NgayXuat as 'Ngày Xuất Kho',Nhap.NgayNhap as 'Ngày Nhập Kho'
	from 
	HangHoa  
	left join (
		select XuatKho.MaLaptop,XuatKho.TenLaptop ,XuatKho.DonGiaXuat,XuatKho.SoLuongXuat,XuatKho.ThanhTien,XuatKho.NgayXuat 
		from XuatKho
	)as Xuat on hanghoa.malaptop = xuat.malaptop
	left join 
	(
		select NhapKho.MaLaptop ,NhapKho.TenLaptop a ,NhapKho.DonGiaNhap ,NhapKho.SoLuongNhap ,NhapKho.ThanhTien ,NhapKho.NgayNhap 
		from  NhapKho
	)as Nhap on nhap.Malaptop = hanghoa.malaptop
	---where Nhap.MaLaptop =  HangHoa.MaLapTop and Xuat.MaLaptop = HangHoa.MaLapTop
)
select * from danhmuchanghoa
create view XuatPhieuNhap
as
(
	SELECT PhieuNhap.MaPhieuNhap as 'Ma' , NhapKho.MaLapTop
	FROM PhieuNhap,NhapKho
	where PhieuNhap.MaPhieuNhap = NhapKho.MaPhieu
)
select *from XuatPhieuNhap
create view XuatPhieuXuat
as
(
	SELECT PhieuXuat.MaPhieuXuat as 'Ma' , XuatKho.MaLapTop
	FROM PhieuXuat,XuatKho
	where PhieuXuat.MaPhieuXuat = XuatKho.MaPhieuXuat
)
create view XuatAll
as
(
-- nhập kho
	SELECT *
	FROM XuatPhieuNhap
	
 
	UNION ALL
-- xuất kho 
	
	SELECT *
	FROM XuatPhieuXuat
	
)
select *from XuatAll
--Tuấn Bổ sung
create function Search(@MaLT varchar(20))
returns table as 
return
(
	select *
	from danhmuchanghoa
	where danhmuchanghoa.[Mã Laptop] = @MaLT

)
select *from Search ('2')

--=============================================================NHẬT=============================================================
alter function CUAHANG_TimKiem(@Ma varchar(20))
returns table as 
return
(
	 Select CuaHang.MaCuaHang as 'Mã cửa hàng', CuaHang.TenCuaHang as 'Tên cửa hàng' , CuaHang.DiaChi as 'Địa chỉ' , CuaHang.SDT as 'Số điện thoại',PhieuXuat.MaPhieuXuat as 'Mã đơn hàng'
	 From CuaHang ,PhieuXuat
	 Where CONCAT(PhieuXuat.MaPhieuXuat,PhieuXuat.MaCuaHang) LIKE '%'+ @Ma +'%' and CuaHang.MaCuaHang = PhieuXuat.MaCuaHang        
)
select *from  CUAHANG_TimKiem ('PV_102')
--load bên form cửa hàng
alter view CUAHANG_Load			-- thay doi
as 
(
	Select CuaHang.MaCuaHang as 'Mã cửa hàng', CuaHang.DiaChi as 'Địa Chỉ',CuaHang.SDT as 'Số điện thoại', CuaHang.TenCuaHang as 'Tên cửa hàng' ,PhieuXuat.MaPhieuXuat as 'Mã đơn hàng'
	From CuaHang,PhieuXuat
	WHERE CuaHang.MaCuaHang = PhieuXuat.MaCuaHang 
)
select *from  CUAHANG_Load
--load bên form print
create view CUAHANG_LoadPrint
as 
(
	Select CuaHang.MaCuaHang as 'Mã cửa hàng', CuaHang.TenCuaHang as 'Tên cửa hàng' , CuaHang.DiaChi as 'Địa Chỉ',CuaHang.SDT as 'Số điện thoại'
	From CuaHang
	
)
--Tìm kiếm trong print Cửa hàng
create function  CUAHANG_SearchPrint(@ma varchar(20))
returns table as 
return
(
	select * 
	from CUAHANG_LoadPrint
	Where CONCAT([Mã cửa hàng],[Tên cửa hàng])  LIKE '%'+ @ma +'%'

)
-- xóa cửa hàng
alter proc CUAHANG_Xoa(@Ma varchar(20))
as 
	update PhieuXuat
	set MaCuaHang = null
	DELETE FROM CuaHang  
	WHERE MaCuaHang = @Ma

exec CUAHANG_Xoa
alter proc CUAHANG_Update(@mch varchar(20),@dc varchar(50),@sdt int, @tch varchar(50))
as 

	UPDATE CuaHang 
	SET  MaCuaHang=@mch,DiaChi=@dc,SDT=@sdt, TenCuaHang=@tch 
	WHERE MaCuaHang=@mch

--nhà cung cấp
create function NHACUNGCAP_TimKiem(@Ma varchar(20))
returns table as 
return
(
	 select NhaCungCap.MaCongTy as 'Mã công ty', NhaCungCap.TenCongTy as 'Tên công ty',NhaCungCap.SDT as 'Số điện thoại', NhaCungCap.DiaChi as 'Địa chỉ' 
	 From NhaCungCap ,PhieuNhap
	 Where CONCAT(PhieuNhap.MaNhaCungCap,PhieuNhap.MaPhieuNhap)  LIKE '%'+ @Ma +'%'  and NhaCungCap.MaCongTy= PhieuNhap.MaNhaCungCap       
)
select *from  NHACUNGCAP_TimKiem ('PV_102')
--Form load của nhà cung cấp
alter view NHACUNGCAP_Load			--thay doi
as
(
	SELECT NhaCungCap.MaCongTy as 'Mã công ty', NhaCungCap.TenCongTy as 'Tên công ty',NhaCungCap.SDT as 'Số điện thoại', NhaCungCap.DiaChi as 'Địa chỉ',PhieuNhap.MaPhieuNhap as 'Mã đơn hàng'
	FROM NhaCungCap,PhieuNhap
	WHERE NhaCungCap.MaCongTy= PhieuNhap.MaNhaCungCap 
)
select *from  NHACUNGCAP_Load

--load bên form Print
create view NHACUNGCAP_LoadPrint
as
(
	SELECT NhaCungCap.MaCongTy as 'Mã công ty', NhaCungCap.TenCongTy as 'Tên công ty',NhaCungCap.SDT as 'Số điện thoại', NhaCungCap.DiaChi as 'Địa chỉ'
	FROM NhaCungCap
	
)
--Tìm kiếm trong NHACUNGCAP Print (mã công ty , tên công ty)
create function  NHACUNGCAP_SearchPrint(@ma varchar(20))
returns table as 
return
(
	select * 
	from NHACUNGCAP_LoadPrint
	Where CONCAT([Mã công ty],[Tên công ty])  LIKE '%'+ @ma +'%'

)


--Xóa nhà cung cấp
create proc NHACUNGCAP_Xoa(@Ma varchar(20))
as 
	update PhieuNhap
	set MaNhaCungCap = null
	
	DELETE FROM NhaCungCap  
	WHERE MaCongTy = @Ma

exec NHACUNGCAP_Xoa 'Cty_102'
--Cập nhật nhà cung cấp
create proc NHACUNGCAP_Update(@Ma varchar(20),@tencty varchar(20),@sdt int, @Diachi varchar(50))
as 
	UPDATE NhaCungCap 
	SET  MaCongTy=@Ma,TenCongTy=@tencty,SDT=@sdt, DiaChi=@Diachi 
	WHERE MaCongTy=@Ma
exec NHACUNGCAP_Update
--============================================CHART=================================
--Nhà cung cấp
alter function NhaCungCap_Chart (@ma varchar(20))	-- mã công ty để hiện tươnng ứng
returns table as				-- thay doi
return
(
	select A.MaNhaCungCap,A.TenCongTy ,Nhapkho.ThanhTien, NhapKho.Thue
	from
	(
		select PhieuNhap.MaPhieuNhap , PhieuNhap.MaNhaCungCap , NhaCungCap.TenCongTy
		from NhaCungCap,PhieuNhap
		where NhaCungCap.MaCongTy = @ma and PhieuNhap.MaNhaCungCap = NhaCungCap.MaCongTy
	) as A, NhapKho
	where NhapKho.MaPhieu = A.MaPhieuNhap
)
select *from NhaCungCap_Chart('NCC_101')

create View NhaCungCap_LoadChart
as
(
		select PhieuNhap.MaPhieuNhap , PhieuNhap.MaNhaCungCap
		from NhaCungCap,PhieuNhap
		where  PhieuNhap.MaNhaCungCap = NhaCungCap.MaCongTy
)
SELECT *FROM NhaCungCap_LoadChart
--Cửa hàng
alter function CuaHang_Chart (@ma varchar(20))	-- mã công ty để hiện tươnng ứng
returns table as		-- thay doi
return
(
	select A.MaCuaHang ,XuatKho.ThanhTien, XuatKho.Thue,A.TenCuaHang
	from
	(
		select PhieuXuat.MaPhieuXuat , PhieuXuat.MaCuaHang ,CuaHang.TenCuaHang
		from CuaHang,PhieuXuat
		where CuaHang.MaCuaHang = @ma and PhieuXuat.MaCuaHang = CuaHang.MaCuaHang
	) as A, XuatKho
	where XuatKho.MaPhieuXuat = A.MaPhieuXuat
)
select *from CuaHang_Chart('CH_10')

create View CuaHang_LoadChart
as
(
		select PhieuXuat.MaCuaHang , PhieuXuat.MaPhieuXuat
		from CuaHang,PhieuXuat
		where  PhieuXuat.MaCuaHang = CuaHang.MaCuaHang
)
--=======================================================Phần Đăng nhập====================================================
create function DangNhap(@usn nvarchar(50),@pass nvarchar(50))
returns table as 
return
(
	SELECT *FROM Login 
	WHERE id=@usn and password =@pass
)
create function DangNhap_Guest(@usn nvarchar(50),@pass nvarchar(50))
returns table as 
return
(
	SELECT *FROM Login_Guest
	WHERE id=@usn and password =@pass
)
--SELECT *FROM DangNhap (,)
