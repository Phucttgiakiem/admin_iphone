using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.DataAccess.Migrations;
using admin_web_sell_phone.Entity;
using admin_web_sell_phone.Models;
using admin_web_sell_phone.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Permissions;
namespace admin_web_sell_phone.Controllers
{
    public class NhanvienController : Controller
    {
        private readonly ApplicationDbContext _context;
        private INhanvienService _Nhanvienservice;
        private IWebHostEnvironment _hostingEnvironment;

        public NhanvienController(ApplicationDbContext context, INhanvienService nhanvienservice, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _Nhanvienservice = nhanvienservice;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = _Nhanvienservice.GetAll().Select(nv => new NhanvienIndexModel
            {
                ID_Nhanvien = nv.ID_Nhanvien,
                Tennhanvien = nv.Tennhanvien,
                Email = nv.Email,
                sdt = nv.sdt
            }).ToList();
            return View(model);
        }


        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Nhanvien,Tennhanvien,Ngaysinh,Diachi,sdt,Email,Hinhanh,username,password")] tb_Nhanvien nhanvien)
        {

            if (ModelState.IsValid)
            {
                await  _Nhanvienservice.CreateAsSync(nhanvien);
               
                return RedirectToAction(nameof(Index));
            };
            return View();
        }
        //Delete 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Select(h => new NhanvienIndexModel
                {
                    ID_Nhanvien = h.ID_Nhanvien,
                    Tennhanvien = h.Tennhanvien,
                    Ngaysinh = (DateTime)h.Ngaysinh,
                    Diachi = h.Diachi,
                    sdt = h.sdt,
                    Email = h.Email,
                    Hinhanh = h.Hinhanh,
                    username = h.username,
                    password = h.password
                })
                .FirstOrDefaultAsync(m => m.ID_Nhanvien == id);

            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(NhanvienIndexModel model)
        {
            var nhanvien = await _context.Nhanvien.FindAsync(model.ID_Nhanvien);
            if (nhanvien == null)
            {
                return NotFound();
            }

            _context.Nhanvien.Remove(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var nhanvien = _Nhanvienservice.GetById(id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            var model = new NhanvienIndexModel
            {
                ID_Nhanvien = nhanvien.ID_Nhanvien,
                Tennhanvien = nhanvien.Tennhanvien,
                Ngaysinh = (DateTime)nhanvien.Ngaysinh,
                Diachi = nhanvien.Diachi,
                sdt = nhanvien.sdt,
                Email = nhanvien.Email,
                Hinhanh = nhanvien.Hinhanh,
                username = nhanvien.username,
                password = nhanvien.password
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Nhanvien,Tennhanvien,Ngaysinh,Diachi,sdt,Email,Hinhanh,username,password")] NhanvienIndexModel nhanvienModel)
        {
            if (id != nhanvienModel.ID_Nhanvien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nhanvien = _Nhanvienservice.GetById(id);
                    nhanvien.ID_Nhanvien = nhanvienModel.ID_Nhanvien;
                    nhanvien.Tennhanvien = nhanvienModel.Tennhanvien;
                    nhanvien.Ngaysinh = nhanvienModel.Ngaysinh;
                    nhanvien.Diachi = nhanvienModel.Diachi;
                    nhanvien.sdt = nhanvienModel.sdt;
                    nhanvien.Email = nhanvienModel.Email;
                    nhanvien.Hinhanh = nhanvienModel.Hinhanh;
                    nhanvien.username = nhanvienModel.username;
                    nhanvien.password = nhanvienModel.password;

                    await _Nhanvienservice.UpdateAsSync(nhanvien);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvienModel.ID_Nhanvien))
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
            return View(nhanvienModel);
        }
        private bool NhanvienExists(int iD_Nhanvien)
        {
            return _context.Nhanvien.Any(n => n.ID_Nhanvien == iD_Nhanvien);
        }
    }
}
