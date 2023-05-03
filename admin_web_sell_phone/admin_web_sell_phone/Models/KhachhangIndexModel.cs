using System.ComponentModel.DataAnnotations;

namespace admin_web_sell_phone.Models
{
    public class KhachhangIndexModel
    {
        [Key]
        
        public int ID_Khachhang { get; set; }
       
        public string TenKhachhang { get; set; }
        
        public int sdt { get; set; }
        
    }
}
