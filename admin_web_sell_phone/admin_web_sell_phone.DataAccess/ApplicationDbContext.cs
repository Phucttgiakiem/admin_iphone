using admin_web_sell_phone.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace admin_web_sell_phone.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<tb_Nhanvien> Nhanvien { get; set; }
        public DbSet<tb_Khachhang> Khachhang { get; set; }
        public DbSet<tb_Nhacungcap> Nhacungcap { get; set; }
        public DbSet<tb_Thuonghieu> Thuonghieu { get; set; }
        public DbSet<tb_Sanpham> Sanpham { get; set; }
        public DbSet<tb_Phieunhap> Phieunhap { get; set; }
        public DbSet<tb_Chitietphieunhap> Chitietphieunhap { get; set; }
        public DbSet<tb_Hoadon> Hoadon { get; set; }
        public DbSet<tb_Chitiethoadon> Chitiethoadon { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Chitiethoadon>().HasNoKey();
            modelBuilder.Entity<tb_Chitietphieunhap>().HasNoKey();
        }
    }
}
