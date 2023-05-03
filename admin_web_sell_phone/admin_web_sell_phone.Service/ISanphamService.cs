using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service
{
    public interface ISanphamService
    {
        Task CreateAsSync(tb_Sanpham newsanpham);
        Task UpdateById(int id);
        Task UpdateAsSync(tb_Sanpham newsanpham);
        Task DeleteById(int id);
        tb_Sanpham GetById(int id);
        IEnumerable<tb_Sanpham> GetAll();

    }
}
