using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Entity
{
    public  class tb_Chitiethoadon
    {
        [Column(TypeName="int")]
        public int Soluongmua { get; set; }
        [Required]
        public int ID_HoaDon { get; set; }
        [ForeignKey("ID_HoaDon")]
        
        public tb_Hoadon tb_Hoadon { get; set; }
        [Required]
        public int ID_SanPham { get; set; }
        [ForeignKey("ID_SanPham")]
        
        public tb_Sanpham tb_Sanpham { get; set; }

    }
}
