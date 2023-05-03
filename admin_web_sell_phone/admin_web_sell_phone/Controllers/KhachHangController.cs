using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Entity;
using admin_web_sell_phone.Models;
using admin_web_sell_phone.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace admin_web_sell_phone.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IKhachhangService _khachhangservice;

        public KhachHangController(ApplicationDbContext context,IKhachhangService khachhangservice)
        {
            _context = context;
            _khachhangservice = khachhangservice;
        }

        public async Task<IActionResult> Index()
        {
            var KhachhangList = await _context.Khachhang
                .Select(nv => new KhachhangIndexModel
                {
                    ID_Khachhang = nv.ID_Khachhang,
                    TenKhachhang = nv.TenKhachhang,
                    sdt = nv.sdt
                })
                .ToListAsync();

            return View(KhachhangList);
        }

        //Thêm khách Hàng

        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Khachhang, TenKhachhang, sdt")] tb_Khachhang khachhang)
        {

            if (ModelState.IsValid)
            {
                await _khachhangservice.UpdateAsSync(khachhang);
                return RedirectToAction(nameof(Index));
            };
            return View();
        }

        //Xóa Khách Hàng
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .Select(h => new KhachhangIndexModel
                {
                    ID_Khachhang = h.ID_Khachhang,
                    TenKhachhang = h.TenKhachhang,
                    sdt = h.sdt,
                })
                .FirstOrDefaultAsync(m => m.ID_Khachhang == id);

            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(KhachhangIndexModel model)
        {
            var khachhang = await _context.Khachhang.FindAsync(model.ID_Khachhang);
            if (khachhang == null)
            {
                return NotFound();
            }

            _context.Khachhang.Remove(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Edit Khách hàng
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var khachhang = _khachhangservice.GetById(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            var model = new KhachhangIndexModel
            {
                ID_Khachhang = khachhang.ID_Khachhang,
                TenKhachhang = khachhang.TenKhachhang,
                sdt = khachhang.sdt
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Khachhang,TenKhachhang,sdt")] KhachhangIndexModel khachhangModel)
        {
            if (id != khachhangModel.ID_Khachhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var khachhang = await _context.Khachhang.FindAsync(id);
                    khachhang.ID_Khachhang = khachhangModel.ID_Khachhang;
                    khachhang.TenKhachhang = khachhangModel.TenKhachhang;

                    khachhang.sdt = khachhangModel.sdt;


                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhangModel.ID_Khachhang))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khachhangModel);
        }

        private bool KhachhangExists(int iD_Khachhang)
        {
            return _context.Khachhang.Any(n => n.ID_Khachhang == iD_Khachhang);
        }
    }
}
