using System.ComponentModel.DataAnnotations;

namespace admin_web_sell_phone.Models
{
    public class SanphamDetail_EditModel
    {
        public int ID_sanpham { get; set; }
        public string? Ten_Dienthoai { get; set; }
        public int GiaBan { get; set; }
        public int Soluong { get; set; }
        public string? Kichthuoc { get; set; }
        public string? Camera { get; set; }
        public string? Mausac { get; set; }
        public string? Pin { get; set; }
        public string? Manhinh { get; set; }
        public string? BaoHanh { get; set; }
        public string? HinhAnh { get; set; }
        public int ID_ThuongHieu { get; set; }

        public IFormFile? Image { get; set; }
    }
}
