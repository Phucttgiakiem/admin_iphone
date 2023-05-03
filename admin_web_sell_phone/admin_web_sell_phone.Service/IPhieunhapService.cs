using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service
{
    public interface IPhieunhapService
    {
        Task CreateAsSync(tb_Phieunhap nhacungcap);
        Task UpdateById(int id);
        Task UpdateAsSync(tb_Phieunhap nhacungcap);
        Task DeleteById(int id);
        tb_Phieunhap GetById(int id);
        IEnumerable<tb_Phieunhap> GetAll();
    }
}
