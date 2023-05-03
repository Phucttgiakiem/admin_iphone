using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service
{
    public interface IThuonghieuService
    {
        Task CreateAsSync(tb_Thuonghieu newthuonghieu);
        Task UpdateById(int id);
        Task UpdateAsSync(tb_Thuonghieu newthuonghieu);
        Task DeleteById(int id);
        tb_Thuonghieu GetById(int id);
        IEnumerable<tb_Thuonghieu> GetAll();
     
    }
}
