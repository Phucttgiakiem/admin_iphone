using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service.implamentation
{
    public class NhanvienService : INhanvienService
    {
        public ApplicationDbContext _context;

        public NhanvienService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsSync(tb_Nhanvien newnhanvien)
        {
            _context.Nhanvien.Add(newnhanvien);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var nhanvien = GetById(id);
            _context.Remove(nhanvien);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<tb_Nhanvien> GetAll()
        {
            return _context.Nhanvien.ToList();
        }

        public tb_Nhanvien GetById(int id)
        {
            return _context.Nhanvien.Where(x => x.ID_Nhanvien == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(tb_Nhanvien newnhanvien)
        {
            _context.Nhanvien.Update(newnhanvien);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var Nhanvien = GetById(id);
            if (Nhanvien != null)
            {
                _context.Nhanvien.Update(Nhanvien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
