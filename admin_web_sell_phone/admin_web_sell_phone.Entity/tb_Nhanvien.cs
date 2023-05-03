using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Entity
{
    public class tb_Nhanvien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Nhanvien { get; set; }
        [StringLength(100)]
        public string? Tennhanvien { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string? Diachi { get; set; }
        public int sdt { get; set; }
        public string? Email { get; set; }
        public string? Hinhanh {get; set; }
        public string? username {get; set; }
        public string? password { get; set; }

    }
}
