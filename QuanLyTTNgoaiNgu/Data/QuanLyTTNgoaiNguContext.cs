using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyTTNgoaiNgu.Models;

namespace QuanLyTTNgoaiNgu.Data
{
    public class QuanLyTTNgoaiNguContext : DbContext
    {
        public QuanLyTTNgoaiNguContext (DbContextOptions<QuanLyTTNgoaiNguContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TAIKHOAN>().HasData(
              // Hoc Vien (1-5)
              new { MaTaiKhoan = 1, TenDangNhap = "hocvien1", MatKhau = "123456", VaiTro = "HocVien" },
              new { MaTaiKhoan = 2, TenDangNhap = "hocvien2", MatKhau = "123456", VaiTro = "HocVien" },
              new { MaTaiKhoan = 3, TenDangNhap = "hocvien3", MatKhau = "123456", VaiTro = "HocVien" },
              new { MaTaiKhoan = 4, TenDangNhap = "hocvien4", MatKhau = "123456", VaiTro = "HocVien" },
              new { MaTaiKhoan = 5, TenDangNhap = "hocvien5", MatKhau = "123456", VaiTro = "HocVien" },

              // Giang Vien (6-10)
              new { MaTaiKhoan = 6, TenDangNhap = "giaovien1", MatKhau = "123456", VaiTro = "GiangVien" },
              new { MaTaiKhoan = 7, TenDangNhap = "giaovien2", MatKhau = "123456", VaiTro = "GiangVien" },
              new { MaTaiKhoan = 8, TenDangNhap = "giaovien3", MatKhau = "123456", VaiTro = "GiangVien" },
              new { MaTaiKhoan = 9, TenDangNhap = "giaovien4", MatKhau = "123456", VaiTro = "GiangVien" },
              new { MaTaiKhoan = 10, TenDangNhap = "giaovien5", MatKhau = "123456", VaiTro = "GiangVien" },

              // Quan Tri Vien (11-15)
              new { MaTaiKhoan = 11, TenDangNhap = "admin1", MatKhau = "admin123", VaiTro = "Admin" },
              new { MaTaiKhoan = 12, TenDangNhap = "admin2", MatKhau = "admin123", VaiTro = "Admin" },
              new { MaTaiKhoan = 13, TenDangNhap = "admin3", MatKhau = "admin123", VaiTro = "Admin" },
              new { MaTaiKhoan = 14, TenDangNhap = "admin4", MatKhau = "admin123", VaiTro = "Admin" },
              new { MaTaiKhoan = 15, TenDangNhap = "admin5", MatKhau = "admin123", VaiTro = "Admin" }
          );

            // ====== KHOAHOC ======
            modelBuilder.Entity<KHOAHOC>().HasData(
                new { MaKhoaHoc = 1, TenKhoaHoc = "Tiếng Anh giao tiếp", MucHocPhi = 1500000.0, MoTa = "Học giao tiếp tiếng Anh cơ bản" },
                new { MaKhoaHoc = 2, TenKhoaHoc = "Tiếng Nhật N5", MucHocPhi = 1800000.0, MoTa = "Học tiếng Nhật sơ cấp N5" },
                new { MaKhoaHoc = 3, TenKhoaHoc = "Tiếng Hàn sơ cấp", MucHocPhi = 1700000.0, MoTa = "Học tiếng Hàn cho người mới bắt đầu" },
                new { MaKhoaHoc = 4, TenKhoaHoc = "Tiếng Trung giao tiếp", MucHocPhi = 1600000.0, MoTa = "Giao tiếp tiếng Trung cơ bản" },
                new { MaKhoaHoc = 5, TenKhoaHoc = "Tiếng Pháp A1", MucHocPhi = 1900000.0, MoTa = "Tiếng Pháp cho người bắt đầu" }
            );

            // ====== GIANGVIEN (6-10) ======
            modelBuilder.Entity<GIANGVIEN>().HasData(
                new { MaGiangVien = 1, HoTen = "Nguyễn Minh Anh", SoDienThoai = "0911222333", ChuyenMon = "Tiếng Anh", Email = "anhgv@gmail.com", MaTaiKhoan = 6 },
                new { MaGiangVien = 2, HoTen = "Trần Nhật Hạ", SoDienThoai = "0911333444", ChuyenMon = "Tiếng Nhật", Email = "hajp@gmail.com", MaTaiKhoan = 7 },
                new { MaGiangVien = 3, HoTen = "Lê Thị Hoa", SoDienThoai = "0911444555", ChuyenMon = "Tiếng Hàn", Email = "hoakr@gmail.com", MaTaiKhoan = 8 },
                new { MaGiangVien = 4, HoTen = "Phạm Quốc Trung", SoDienThoai = "0911555666", ChuyenMon = "Tiếng Trung", Email = "trungcn@gmail.com", MaTaiKhoan = 9 },
                new { MaGiangVien = 5, HoTen = "Vũ Thanh Pháp", SoDienThoai = "0911666777", ChuyenMon = "Tiếng Pháp", Email = "phapfr@gmail.com", MaTaiKhoan = 10 }
            );

            // ====== LOPHOC ======
            modelBuilder.Entity<LOPHOC>().HasData(
                new { MaLopHoc = 1, TenLop = "Anh Giao Tiep 101", LichHoc = new DateTime(2025, 8, 1), MaGiangVien = 1, MaKhoaHoc = 1 },
                new { MaLopHoc = 2, TenLop = "Nhat N5 Sáng", LichHoc = new DateTime(2025, 8, 2), MaGiangVien = 2, MaKhoaHoc = 2 },
                new { MaLopHoc = 3, TenLop = "Han Sơ Cấp 1", LichHoc = new DateTime(2025, 8, 3), MaGiangVien = 3, MaKhoaHoc = 3 },
                new { MaLopHoc = 4, TenLop = "Trung Giao Tiep 1", LichHoc = new DateTime(2025, 8, 4), MaGiangVien = 4, MaKhoaHoc = 4 },
                new { MaLopHoc = 5, TenLop = "Phap A1 Tối", LichHoc = new DateTime(2025, 8, 5), MaGiangVien = 5, MaKhoaHoc = 5 }
            );

            // ====== HOCVIEN (1-5) ======
            modelBuilder.Entity<HOCVIEN>().HasData(
                new { MaHocVien = 1, HoTen = "Trần Hồng Nhung", SoDienThoai = "0931222333", NgaySinh = new DateTime(2003, 4, 12), Email = "nhung@gmail.com", DiaChi = "Hà Nội", MaTaiKhoan = 1 },
                new { MaHocVien = 2, HoTen = "Ngô Đức Long", SoDienThoai = "0931333444", NgaySinh = new DateTime(2002, 9, 10), Email = "long@gmail.com", DiaChi = "Đà Nẵng", MaTaiKhoan = 2 },
                new { MaHocVien = 3, HoTen = "Vũ Thị Thu", SoDienThoai = "0931444555", NgaySinh = new DateTime(2001, 12, 5), Email = "thu@gmail.com", DiaChi = "TP.HCM", MaTaiKhoan = 3 },
                new { MaHocVien = 4, HoTen = "Lê Văn Nam", SoDienThoai = "0931555666", NgaySinh = new DateTime(2000, 6, 22), Email = "nam@gmail.com", DiaChi = "Hải Phòng", MaTaiKhoan = 4 },
                new { MaHocVien = 5, HoTen = "Phạm Thị Mai", SoDienThoai = "0931666777", NgaySinh = new DateTime(2004, 2, 14), Email = "mai@gmail.com", DiaChi = "Cần Thơ", MaTaiKhoan = 5 }
            );

            // ====== PHIEUDANGKY ======
            modelBuilder.Entity<PHIEUDANGKY>().HasData(
                new { MaDangKy = 1, NgayDangKy = new DateTime(2025, 7, 10), MaHocVien = 1, MaLopHoc = 1 },
                new { MaDangKy = 2, NgayDangKy = new DateTime(2025, 7, 11), MaHocVien = 2, MaLopHoc = 2 },
                new { MaDangKy = 3, NgayDangKy = new DateTime(2025, 7, 12), MaHocVien = 3, MaLopHoc = 3 },
                new { MaDangKy = 4, NgayDangKy = new DateTime(2025, 7, 13), MaHocVien = 4, MaLopHoc = 4 },
                new { MaDangKy = 5, NgayDangKy = new DateTime(2025, 7, 14), MaHocVien = 5, MaLopHoc = 5 }
            );

            // ====== HOCPHI ======
            modelBuilder.Entity<HOCPHI>().HasData(
     new { MaHocPhi = 1, MaDangKy = 1, TrangThai = true, NgayNop = new DateTime(2025, 7, 20) },
     new { MaHocPhi = 2, MaDangKy = 2, TrangThai = true, NgayNop = new DateTime(2025, 7, 21) },
     new { MaHocPhi = 3, MaDangKy = 3, TrangThai = false, NgayNop = (DateTime?)null },
     new { MaHocPhi = 4, MaDangKy = 4, TrangThai = true, NgayNop = new DateTime(2025, 7, 23) },
     new { MaHocPhi = 5, MaDangKy = 5, TrangThai = false, NgayNop = (DateTime?)null }
 );


            // ====== KETQUAHOCTAP ======
            modelBuilder.Entity<KETQUAHOCTAP>().HasData(
                new { MaKetQua = 1, MaHocVien = 1, MaLopHoc = 1, Diem = 8.0f, ChuyenCan = 9.0f },
                new { MaKetQua = 2, MaHocVien = 2, MaLopHoc = 2, Diem = 7.5f, ChuyenCan = 8.5f },
                new { MaKetQua = 3, MaHocVien = 3, MaLopHoc = 3, Diem = 9.0f, ChuyenCan = 9.5f },
                new { MaKetQua = 4, MaHocVien = 4, MaLopHoc = 4, Diem = 7.0f, ChuyenCan = 8.0f },
                new { MaKetQua = 5, MaHocVien = 5, MaLopHoc = 5, Diem = 8.5f, ChuyenCan = 9.0f }
            );
        }


        public DbSet<QuanLyTTNgoaiNgu.Models.GIANGVIEN> GIANGVIEN { get; set; } = default!;
        public DbSet<QuanLyTTNgoaiNgu.Models.HOCPHI> HOCPHI { get; set; } = default!;
        public DbSet<QuanLyTTNgoaiNgu.Models.HOCVIEN> HOCVIEN { get; set; } = default!;
        public DbSet<QuanLyTTNgoaiNgu.Models.KETQUAHOCTAP> KETQUAHOCTAP { get; set; } = default!;
        public DbSet<QuanLyTTNgoaiNgu.Models.KHOAHOC> KHOAHOC { get; set; } = default!;
        public DbSet<QuanLyTTNgoaiNgu.Models.LOPHOC> LOPHOC { get; set; } = default!;
        public DbSet<QuanLyTTNgoaiNgu.Models.PHIEUDANGKY> PHIEUDANGKY { get; set; } = default!;
        public DbSet<QuanLyTTNgoaiNgu.Models.QUANTRIVIEN> QUANTRIVIEN { get; set; } = default!;
        public DbSet<QuanLyTTNgoaiNgu.Models.TAIKHOAN> TAIKHOAN { get; set; } = default!;
    }
}
