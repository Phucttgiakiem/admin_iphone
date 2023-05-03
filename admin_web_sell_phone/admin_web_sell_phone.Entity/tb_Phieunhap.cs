using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Entity
{
    public class tb_Phieunhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Phieunhap { get; set; }
        public DateTime Ngay_nhap { get; set; }
        public int Tong_gia { get; set; }
        [Required]
        public int ID_NhaCungCap { get; set; }
        [ForeignKey("ID_NhaCungCap")]
        public tb_Nhacungcap tb_Nhacungcap { get; set; }

    }
}
