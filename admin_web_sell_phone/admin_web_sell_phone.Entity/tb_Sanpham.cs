using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Entity
{
    public class tb_Sanpham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_sanpham { get; set; }
        [StringLength(120)]
        public string? Ten_Dienthoai { get; set; }
        public int GiaBan { get; set; }
        public int Soluong { get; set; }
        public string? Kichthuoc { get; set; }
        public string? Camera { get; set; }
        public string? Mausac { get; set; }
        public string? Pin { get; set; }
        public string? Manhinh { get; set; }
        public string? BaoHanh {get; set; }
        public string HinhAnh { get; set; }
        [Required]
        public int ID_ThuongHieu { get; set; }
        [ForeignKey("ID_ThuongHieu")]
        public tb_Thuonghieu tb_thuonghieu { get; set; }
    }
}
