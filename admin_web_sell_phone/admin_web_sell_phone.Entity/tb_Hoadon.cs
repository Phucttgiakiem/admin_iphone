using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Entity
{
    public class tb_Hoadon
    {
        [Key]
        public int ID_Hoadon { get; set; }
        public int ID_KhachHang { get; set; }
        [ForeignKey("ID_KhachHang")]
        public tb_Khachhang tb_Khachhang { get; set; }
        public int ID_NhanVien { get; set; }
        [ForeignKey("ID_NhanVien")]
        
        public tb_Nhanvien tb_Nhanvien { get; set; }
        public DateTime Ngaytaophieu { get; set; }
        public int TongDon { get; set; }
        
        

    }
}
