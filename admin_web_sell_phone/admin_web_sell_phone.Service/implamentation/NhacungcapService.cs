using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service.implamentation
{
    public class NhacungcapService : INhacungcapService
    {
        public ApplicationDbContext _context;

        public NhacungcapService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task CreateAsSync(tb_Nhacungcap nhacungcap)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_Nhacungcap> GetAll()
        {
            return _context.Nhacungcap.ToList();
        }

        public tb_Nhacungcap GetById(int id)
        {
            return _context.Nhacungcap.Where(predicate: x => x.ID_Nhacungcap == id).FirstOrDefault();
        }

        public Task UpdateAsSync(tb_Nhacungcap nhacungcap)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
