using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Entity
{
    public class tb_Nhacungcap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Nhacungcap { get; set; }
        [StringLength(100)]
        public string? Tennhacungcap { get; set; }
        public string? Diachi { get; set; }
        public int sdt { get; set; }

    }
}
