using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_web_sell_phone.Service.implamentation
{
    public class SanphamService : ISanphamService
    {
        public ApplicationDbContext _context;
        public SanphamService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(tb_Sanpham newsanpham)
        {
            _context.Sanpham.Update(newsanpham);
            await _context.SaveChangesAsync();
        }

        public Task CreateAsSync(tb_Phieunhap nhacungcap)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var sanpham = GetById(id);
            _context.Remove(sanpham);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<tb_Sanpham> GetAll()
        {
            return _context.Sanpham.ToList();
        }

        public tb_Sanpham GetById(int id)
        {
            return _context.Sanpham.Where(x => x.ID_sanpham == id).FirstOrDefault();
            
        }

        public async Task UpdateAsSync(tb_Sanpham newsanpham)
        {
            _context.Sanpham.Update(newsanpham);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsSync(tb_Phieunhap nhacungcap)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(int id)
        {
            var sanpham = GetById(id);
            if(sanpham != null)
            {
                _context.Sanpham.Add(sanpham);
                await _context.SaveChangesAsync();
            }
        }
    }
}
