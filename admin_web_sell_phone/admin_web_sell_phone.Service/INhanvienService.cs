using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service
{
    public interface INhanvienService
    {
        Task CreateAsSync(tb_Nhanvien newnhanvien);
        Task UpdateById(int id);
        Task UpdateAsSync(tb_Nhanvien newnhanvien);
        Task DeleteById(int id);
        tb_Nhanvien GetById(int id);
        IEnumerable<tb_Nhanvien> GetAll();
    }
}
