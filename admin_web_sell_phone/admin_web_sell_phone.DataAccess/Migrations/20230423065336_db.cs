using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admin_web_sell_phone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khachhang",
                columns: table => new
                {
                    ID_Khachhang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachhang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sdt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhang", x => x.ID_Khachhang);
                });

            migrationBuilder.CreateTable(
                name: "Nhacungcap",
                columns: table => new
                {
                    ID_Nhacungcap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tennhacungcap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhacungcap", x => x.ID_Nhacungcap);
                });

            migrationBuilder.CreateTable(
                name: "Nhanvien",
                columns: table => new
                {
                    ID_Nhanvien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tennhanvien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdt = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanvien", x => x.ID_Nhanvien);
                });

            migrationBuilder.CreateTable(
                name: "Thuonghieu",
                columns: table => new
                {
                    Id_Thuonghieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenthuonghieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuonghieu", x => x.Id_Thuonghieu);
                });

            migrationBuilder.CreateTable(
                name: "Phieunhap",
                columns: table => new
                {
                    ID_Phieunhap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_nhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tong_gia = table.Column<int>(type: "int", nullable: false),
                    ID_NhaCungCap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieunhap", x => x.ID_Phieunhap);
                    table.ForeignKey(
                        name: "FK_Phieunhap_Nhacungcap_ID_NhaCungCap",
                        column: x => x.ID_NhaCungCap,
                        principalTable: "Nhacungcap",
                        principalColumn: "ID_Nhacungcap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hoadon",
                columns: table => new
                {
                    ID_Hoadon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_KhachHang = table.Column<int>(type: "int", nullable: false),
                    ID_NhanVien = table.Column<int>(type: "int", nullable: false),
                    Ngaytaophieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongDon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadon", x => x.ID_Hoadon);
                    table.ForeignKey(
                        name: "FK_Hoadon_Khachhang_ID_KhachHang",
                        column: x => x.ID_KhachHang,
                        principalTable: "Khachhang",
                        principalColumn: "ID_Khachhang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hoadon_Nhanvien_ID_NhanVien",
                        column: x => x.ID_NhanVien,
                        principalTable: "Nhanvien",
                        principalColumn: "ID_Nhanvien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    ID_sanpham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Dienthoai = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    GiaBan = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Kichthuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Camera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mausac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manhinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_ThuongHieu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.ID_sanpham);
                    table.ForeignKey(
                        name: "FK_Sanpham_Thuonghieu_ID_ThuongHieu",
                        column: x => x.ID_ThuongHieu,
                        principalTable: "Thuonghieu",
                        principalColumn: "Id_Thuonghieu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitiethoadon",
                columns: table => new
                {
                    Soluongmua = table.Column<int>(type: "int", nullable: false),
                    ID_HoaDon = table.Column<int>(type: "int", nullable: false),
                    ID_SanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Chitiethoadon_Hoadon_ID_HoaDon",
                        column: x => x.ID_HoaDon,
                        principalTable: "Hoadon",
                        principalColumn: "ID_Hoadon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitiethoadon_Sanpham_ID_SanPham",
                        column: x => x.ID_SanPham,
                        principalTable: "Sanpham",
                        principalColumn: "ID_sanpham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitietphieunhap",
                columns: table => new
                {
                    Soluongnhap = table.Column<int>(type: "int", nullable: false),
                    Gianhap = table.Column<int>(type: "int", nullable: false),
                    ID_PhieuNhap = table.Column<int>(type: "int", nullable: false),
                    ID_SanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Chitietphieunhap_Phieunhap_ID_PhieuNhap",
                        column: x => x.ID_PhieuNhap,
                        principalTable: "Phieunhap",
                        principalColumn: "ID_Phieunhap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietphieunhap_Sanpham_ID_SanPham",
                        column: x => x.ID_SanPham,
                        principalTable: "Sanpham",
                        principalColumn: "ID_sanpham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitiethoadon_ID_HoaDon",
                table: "Chitiethoadon",
                column: "ID_HoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_Chitiethoadon_ID_SanPham",
                table: "Chitiethoadon",
                column: "ID_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietphieunhap_ID_PhieuNhap",
                table: "Chitietphieunhap",
                column: "ID_PhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietphieunhap_ID_SanPham",
                table: "Chitietphieunhap",
                column: "ID_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadon_ID_KhachHang",
                table: "Hoadon",
                column: "ID_KhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadon_ID_NhanVien",
                table: "Hoadon",
                column: "ID_NhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Phieunhap_ID_NhaCungCap",
                table: "Phieunhap",
                column: "ID_NhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_ID_ThuongHieu",
                table: "Sanpham",
                column: "ID_ThuongHieu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitiethoadon");

            migrationBuilder.DropTable(
                name: "Chitietphieunhap");

            migrationBuilder.DropTable(
                name: "Hoadon");

            migrationBuilder.DropTable(
                name: "Phieunhap");

            migrationBuilder.DropTable(
                name: "Sanpham");

            migrationBuilder.DropTable(
                name: "Khachhang");

            migrationBuilder.DropTable(
                name: "Nhanvien");

            migrationBuilder.DropTable(
                name: "Nhacungcap");

            migrationBuilder.DropTable(
                name: "Thuonghieu");
        }
    }
}
