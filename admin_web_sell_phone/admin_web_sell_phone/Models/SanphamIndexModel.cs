using admin_web_sell_phone.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admin_web_sell_phone.Models
{
    public class SanphamIndexModel
    {
        public int ID_sanpham { get; set; }
       
        public string? Ten_Dienthoai { get; set; }
        public string Hinhanh { get; set; }
        public string Tenthuonghieu { get; set; }
    }
}
