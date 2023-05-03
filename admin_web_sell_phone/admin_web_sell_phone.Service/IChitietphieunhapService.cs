using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service
{
    public interface IChitietphieunhapService
    {
        Task CreateAsSync(tb_Chitietphieunhap ctpn);
        Task UpdateById(int id);
        Task UpdateAsSync(tb_Chitietphieunhap ctpn);
        Task DeleteById(int id);
        IEnumerable<tb_Chitietphieunhap> GetById(int id1);
        IEnumerable<tb_Chitietphieunhap> GetAll();
        
    }
}
