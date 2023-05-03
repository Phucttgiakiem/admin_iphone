using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service.implamentation
{
    public class ChitietphieunhapService : IChitietphieunhapService
    {
        public ApplicationDbContext _context;
        public ChitietphieunhapService (ApplicationDbContext context)
        {
            _context = context;
        }
        public Task CreateAsSync(tb_Chitietphieunhap ctpn)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_Chitietphieunhap> GetAll()
        {
            return _context.Chitietphieunhap.ToList();
        }

        public IEnumerable<tb_Chitietphieunhap> GetById(int id1)
        {
            return _context.Chitietphieunhap.Where(ctpn => ctpn.ID_PhieuNhap == id1).ToList();
        }
        public Task UpdateAsSync(tb_Chitietphieunhap ctpn)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
