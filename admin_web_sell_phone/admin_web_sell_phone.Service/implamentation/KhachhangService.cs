using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service.implamentation
{
    public class KhachhangService : IKhachhangService
    {
        public ApplicationDbContext _context;

        public KhachhangService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(tb_Khachhang newkhachhang)
        {
            _context.Khachhang.Add(newkhachhang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var khachhang = GetById(id);
            _context.Remove(khachhang);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<tb_Khachhang> GetAll()
        {
            return _context.Khachhang.ToList();
        }

        public tb_Khachhang GetById(int id)
        {
            return _context.Khachhang.Where(x => x.ID_Khachhang == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(tb_Khachhang newkhachhang)
        {
            _context.Khachhang.Update(newkhachhang);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var khachhang = GetById(id);
            if (khachhang != null)
            {
                _context.Khachhang.Update(khachhang);
                await _context.SaveChangesAsync();
            }
        }
    }
}
