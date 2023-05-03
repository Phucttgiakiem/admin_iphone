using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service
{
    public interface INhacungcapService
    {
        Task CreateAsSync(tb_Nhacungcap nhacungcap);
        Task UpdateById(int id);
        Task UpdateAsSync(tb_Nhacungcap nhacungcap);
        Task DeleteById(int id);
        tb_Nhacungcap GetById(int id);
        IEnumerable<tb_Nhacungcap> GetAll();
    }
}
