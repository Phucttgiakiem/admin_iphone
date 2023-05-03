using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service
{
    public interface IKhachhangService
    {
        Task CreateAsSync(tb_Khachhang newkhachhang);
        Task UpdateById(int id);
        Task UpdateAsSync(tb_Khachhang newkhachhang);
        Task DeleteById(int id);
        tb_Khachhang GetById(int id);
        IEnumerable<tb_Khachhang> GetAll();
    }
}
