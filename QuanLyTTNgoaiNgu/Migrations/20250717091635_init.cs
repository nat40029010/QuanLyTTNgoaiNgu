using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyTTNgoaiNgu.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHOAHOC",
                columns: table => new
                {
                    MaKhoaHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MucHocPhi = table.Column<double>(type: "float", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHOAHOC", x => x.MaKhoaHoc);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAIKHOAN", x => x.MaTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "GIANGVIEN",
                columns: table => new
                {
                    MaGiangVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ChuyenMon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIANGVIEN", x => x.MaGiangVien);
                    table.ForeignKey(
                        name: "FK_GIANGVIEN_TAIKHOAN_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TAIKHOAN",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HOCVIEN",
                columns: table => new
                {
                    MaHocVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false),
                    TAIKHOANMaTaiKhoan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOCVIEN", x => x.MaHocVien);
                    table.ForeignKey(
                        name: "FK_HOCVIEN_TAIKHOAN_TAIKHOANMaTaiKhoan",
                        column: x => x.TAIKHOANMaTaiKhoan,
                        principalTable: "TAIKHOAN",
                        principalColumn: "MaTaiKhoan");
                });

            migrationBuilder.CreateTable(
                name: "QUANTRIVIEN",
                columns: table => new
                {
                    MaQuanTriVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuanTriVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false),
                    TAIKHOANSMaTaiKhoan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUANTRIVIEN", x => x.MaQuanTriVien);
                    table.ForeignKey(
                        name: "FK_QUANTRIVIEN_TAIKHOAN_TAIKHOANSMaTaiKhoan",
                        column: x => x.TAIKHOANSMaTaiKhoan,
                        principalTable: "TAIKHOAN",
                        principalColumn: "MaTaiKhoan");
                });

            migrationBuilder.CreateTable(
                name: "LOPHOC",
                columns: table => new
                {
                    MaLopHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LichHoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaGiangVien = table.Column<int>(type: "int", nullable: false),
                    MaKhoaHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOPHOC", x => x.MaLopHoc);
                    table.ForeignKey(
                        name: "FK_LOPHOC_GIANGVIEN_MaGiangVien",
                        column: x => x.MaGiangVien,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGiangVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOPHOC_KHOAHOC_MaKhoaHoc",
                        column: x => x.MaKhoaHoc,
                        principalTable: "KHOAHOC",
                        principalColumn: "MaKhoaHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KETQUAHOCTAP",
                columns: table => new
                {
                    MaKetQua = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diem = table.Column<float>(type: "real", nullable: false),
                    ChuyenCan = table.Column<float>(type: "real", nullable: false),
                    MaHocVien = table.Column<int>(type: "int", nullable: false),
                    MaLopHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KETQUAHOCTAP", x => x.MaKetQua);
                    table.ForeignKey(
                        name: "FK_KETQUAHOCTAP_HOCVIEN_MaHocVien",
                        column: x => x.MaHocVien,
                        principalTable: "HOCVIEN",
                        principalColumn: "MaHocVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KETQUAHOCTAP_LOPHOC_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LOPHOC",
                        principalColumn: "MaLopHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUDANGKY",
                columns: table => new
                {
                    MaDangKy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaHocVien = table.Column<int>(type: "int", nullable: false),
                    MaLopHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUDANGKY", x => x.MaDangKy);
                    table.ForeignKey(
                        name: "FK_PHIEUDANGKY_HOCVIEN_MaHocVien",
                        column: x => x.MaHocVien,
                        principalTable: "HOCVIEN",
                        principalColumn: "MaHocVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PHIEUDANGKY_LOPHOC_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LOPHOC",
                        principalColumn: "MaLopHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HOCPHI",
                columns: table => new
                {
                    MaHocPhi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDangKy = table.Column<int>(type: "int", nullable: false),
                    NgayNop = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOCPHI", x => x.MaHocPhi);
                    table.ForeignKey(
                        name: "FK_HOCPHI_PHIEUDANGKY_MaDangKy",
                        column: x => x.MaDangKy,
                        principalTable: "PHIEUDANGKY",
                        principalColumn: "MaDangKy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HOCVIEN",
                columns: new[] { "MaHocVien", "DiaChi", "Email", "HoTen", "MaTaiKhoan", "NgaySinh", "SoDienThoai", "TAIKHOANMaTaiKhoan" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "nhung@gmail.com", "Trần Hồng Nhung", 1, new DateTime(2003, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "0931222333", null },
                    { 2, "Đà Nẵng", "long@gmail.com", "Ngô Đức Long", 2, new DateTime(2002, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "0931333444", null },
                    { 3, "TP.HCM", "thu@gmail.com", "Vũ Thị Thu", 3, new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "0931444555", null },
                    { 4, "Hải Phòng", "nam@gmail.com", "Lê Văn Nam", 4, new DateTime(2000, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "0931555666", null },
                    { 5, "Cần Thơ", "mai@gmail.com", "Phạm Thị Mai", 5, new DateTime(2004, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "0931666777", null }
                });

            migrationBuilder.InsertData(
                table: "KHOAHOC",
                columns: new[] { "MaKhoaHoc", "MoTa", "MucHocPhi", "TenKhoaHoc" },
                values: new object[,]
                {
                    { 1, "Học giao tiếp tiếng Anh cơ bản", 1500000.0, "Tiếng Anh giao tiếp" },
                    { 2, "Học tiếng Nhật sơ cấp N5", 1800000.0, "Tiếng Nhật N5" },
                    { 3, "Học tiếng Hàn cho người mới bắt đầu", 1700000.0, "Tiếng Hàn sơ cấp" },
                    { 4, "Giao tiếp tiếng Trung cơ bản", 1600000.0, "Tiếng Trung giao tiếp" },
                    { 5, "Tiếng Pháp cho người bắt đầu", 1900000.0, "Tiếng Pháp A1" }
                });

            migrationBuilder.InsertData(
                table: "TAIKHOAN",
                columns: new[] { "MaTaiKhoan", "MatKhau", "TenDangNhap", "VaiTro" },
                values: new object[,]
                {
                    { 1, "123456", "hocvien1", "HocVien" },
                    { 2, "123456", "hocvien2", "HocVien" },
                    { 3, "123456", "hocvien3", "HocVien" },
                    { 4, "123456", "hocvien4", "HocVien" },
                    { 5, "123456", "hocvien5", "HocVien" },
                    { 6, "123456", "giaovien1", "GiangVien" },
                    { 7, "123456", "giaovien2", "GiangVien" },
                    { 8, "123456", "giaovien3", "GiangVien" },
                    { 9, "123456", "giaovien4", "GiangVien" },
                    { 10, "123456", "giaovien5", "GiangVien" },
                    { 11, "admin123", "admin1", "Admin" },
                    { 12, "admin123", "admin2", "Admin" },
                    { 13, "admin123", "admin3", "Admin" },
                    { 14, "admin123", "admin4", "Admin" },
                    { 15, "admin123", "admin5", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "GIANGVIEN",
                columns: new[] { "MaGiangVien", "ChuyenMon", "Email", "HoTen", "MaTaiKhoan", "SoDienThoai" },
                values: new object[,]
                {
                    { 1, "Tiếng Anh", "anhgv@gmail.com", "Nguyễn Minh Anh", 6, "0911222333" },
                    { 2, "Tiếng Nhật", "hajp@gmail.com", "Trần Nhật Hạ", 7, "0911333444" },
                    { 3, "Tiếng Hàn", "hoakr@gmail.com", "Lê Thị Hoa", 8, "0911444555" },
                    { 4, "Tiếng Trung", "trungcn@gmail.com", "Phạm Quốc Trung", 9, "0911555666" },
                    { 5, "Tiếng Pháp", "phapfr@gmail.com", "Vũ Thanh Pháp", 10, "0911666777" }
                });

            migrationBuilder.InsertData(
                table: "LOPHOC",
                columns: new[] { "MaLopHoc", "LichHoc", "MaGiangVien", "MaKhoaHoc", "TenLop" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Anh Giao Tiep 101" },
                    { 2, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Nhat N5 Sáng" },
                    { 3, new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Han Sơ Cấp 1" },
                    { 4, new DateTime(2025, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Trung Giao Tiep 1" },
                    { 5, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "Phap A1 Tối" }
                });

            migrationBuilder.InsertData(
                table: "KETQUAHOCTAP",
                columns: new[] { "MaKetQua", "ChuyenCan", "Diem", "MaHocVien", "MaLopHoc" },
                values: new object[,]
                {
                    { 1, 9f, 8f, 1, 1 },
                    { 2, 8.5f, 7.5f, 2, 2 },
                    { 3, 9.5f, 9f, 3, 3 },
                    { 4, 8f, 7f, 4, 4 },
                    { 5, 9f, 8.5f, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "PHIEUDANGKY",
                columns: new[] { "MaDangKy", "MaHocVien", "MaLopHoc", "NgayDangKy" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 4, new DateTime(2025, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 5, new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "HOCPHI",
                columns: new[] { "MaHocPhi", "MaDangKy", "NgayNop", "TrangThai" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 2, 2, new DateTime(2025, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 3, 3, null, false },
                    { 4, 4, new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 5, 5, null, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GIANGVIEN_MaTaiKhoan",
                table: "GIANGVIEN",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_HOCPHI_MaDangKy",
                table: "HOCPHI",
                column: "MaDangKy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HOCVIEN_TAIKHOANMaTaiKhoan",
                table: "HOCVIEN",
                column: "TAIKHOANMaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_KETQUAHOCTAP_MaHocVien",
                table: "KETQUAHOCTAP",
                column: "MaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_KETQUAHOCTAP_MaLopHoc",
                table: "KETQUAHOCTAP",
                column: "MaLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LOPHOC_MaGiangVien",
                table: "LOPHOC",
                column: "MaGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_LOPHOC_MaKhoaHoc",
                table: "LOPHOC",
                column: "MaKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDANGKY_MaHocVien",
                table: "PHIEUDANGKY",
                column: "MaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDANGKY_MaLopHoc",
                table: "PHIEUDANGKY",
                column: "MaLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_QUANTRIVIEN_TAIKHOANSMaTaiKhoan",
                table: "QUANTRIVIEN",
                column: "TAIKHOANSMaTaiKhoan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HOCPHI");

            migrationBuilder.DropTable(
                name: "KETQUAHOCTAP");

            migrationBuilder.DropTable(
                name: "QUANTRIVIEN");

            migrationBuilder.DropTable(
                name: "PHIEUDANGKY");

            migrationBuilder.DropTable(
                name: "HOCVIEN");

            migrationBuilder.DropTable(
                name: "LOPHOC");

            migrationBuilder.DropTable(
                name: "GIANGVIEN");

            migrationBuilder.DropTable(
                name: "KHOAHOC");

            migrationBuilder.DropTable(
                name: "TAIKHOAN");
        }
    }
}
