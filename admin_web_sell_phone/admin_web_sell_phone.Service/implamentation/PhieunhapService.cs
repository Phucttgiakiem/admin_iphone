using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service.implamentation
{
    public class PhieunhapService : IPhieunhapService
    {
        public ApplicationDbContext _context;
        public PhieunhapService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task CreateAsSync(tb_Phieunhap nhacungcap)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_Phieunhap> GetAll()
        {
            return _context.Phieunhap.ToList();
        }

        public tb_Phieunhap GetById(int id)
        {
            return _context.Phieunhap.Where(x => x.ID_Phieunhap == id).FirstOrDefault();
        }

        public Task UpdateAsSync(tb_Phieunhap nhacungcap)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
