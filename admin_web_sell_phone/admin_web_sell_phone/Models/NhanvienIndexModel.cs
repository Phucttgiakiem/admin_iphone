using System.ComponentModel.DataAnnotations;

namespace admin_web_sell_phone.Models
{
    public class NhanvienIndexModel
    {

        public int ID_Nhanvien { get; set; }
        
        public string Tennhanvien { get; set; }
       
        public DateTime Ngaysinh { get; set; }
        
        public string Diachi { get; set; }
        
        public int sdt { get; set; }
        
        public string Email { get   ; set; }
        
        public string Hinhanh { get; set; }
        
        public string username {get; set; }
       
        public string password { get; set; }
    }
}
