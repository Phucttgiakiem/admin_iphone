using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Entity
{
    public class tb_Chitietphieunhap
    {
        public int Soluongnhap { get; set; }
        public int Gianhap { get; set; }
        [Required]
        public int ID_PhieuNhap { get; set; }
        [ForeignKey("ID_PhieuNhap")]
        public tb_Phieunhap tb_phieunhap { get; set; }
        [Required]
        public int ID_SanPham { get; set; }
        [ForeignKey("ID_SanPham")]
        public tb_Sanpham tb_sanpham { get; set; }

        
    }
}
