using admin_web_sell_phone.Entity;
using admin_web_sell_phone.Models;
using admin_web_sell_phone.Service;
using Microsoft.AspNetCore.Mvc;
using admin_web_sell_phone.Service.implamentation;
using admin_web_sell_phone.DataAccess.Migrations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace admin_web_sell_phone.Controllers
{
    public class SanphamController : Controller
    {
        private ISanphamService _sanphamService;
        private IWebHostEnvironment _hostingEnvironment;
        private IThuonghieuService _thuonghieuService;
       
        public SanphamController(ISanphamService employeeService, IWebHostEnvironment hostingEnvironment,IThuonghieuService thuonghieuservice)
        {
            _sanphamService = employeeService;
            _hostingEnvironment = hostingEnvironment;
            _thuonghieuService = thuonghieuservice;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _sanphamService.GetAll().Select(sp => new SanphamIndexModel
            {
                ID_sanpham = sp.ID_sanpham,
                Ten_Dienthoai = sp.Ten_Dienthoai,
                Hinhanh = sp.HinhAnh,
                Tenthuonghieu = _thuonghieuService.GetById(sp.ID_ThuongHieu).Tenthuonghieu
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Brand = _thuonghieuService.GetAll();
            var model = new SanphamCreateModel
            {
                thuonghieu = new SelectList(Brand, "Id_Thuonghieu", "Tenthuonghieu")
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanphamCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var sanpham = new tb_Sanpham
                {
                    ID_sanpham = model.ID_sanpham,
                    Ten_Dienthoai = model.Ten_Dienthoai,
                    GiaBan = model.GiaBan,
                    Soluong = model.Soluong,
                    Kichthuoc = model.Kichthuoc,
                    Camera = model.Camera,
                    Mausac = model.Mausac,
                    Manhinh = model.Manhinh,
                    Pin = model.Pin,
                    BaoHanh = model.BaoHanh,
                    ID_ThuongHieu = model.ID_ThuongHieu
                };
                if (model.Image != null)
                {
                    var filename = Path.GetFileNameWithoutExtension(model.Image.FileName);
                    var filepath = Path.Combine(_hostingEnvironment.WebRootPath, "Content/img", model.Image.FileName);
                    using var filestream = new FileStream(filepath, FileMode.Create);
                    model.Image.CopyTo(filestream);
                    sanpham.HinhAnh = filename;
                }
                else
                {
                    sanpham.HinhAnh = "default-thumbnail.png";
                }
                await _sanphamService.UpdateAsSync(sanpham);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var sanPham = _sanphamService.GetById(id);
            
            var model = new SanphamDetail_EditModel
            {
                ID_sanpham = sanPham.ID_sanpham,
                Ten_Dienthoai = sanPham.Ten_Dienthoai,
                GiaBan = sanPham.GiaBan,
                Soluong = sanPham.Soluong,
                Kichthuoc = sanPham.Kichthuoc,
                Camera = sanPham.Camera,
                Mausac = sanPham.Mausac,
                Pin = sanPham.Pin,
                Manhinh = sanPham.Manhinh,
                BaoHanh = sanPham.BaoHanh,
                HinhAnh = sanPham.HinhAnh,
                ID_ThuongHieu = sanPham.ID_ThuongHieu
            };
            ViewBag.thuonghieu = _thuonghieuService.GetById(sanPham.ID_ThuongHieu).Tenthuonghieu;
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit (int id)
        {
            var sanPham = _sanphamService.GetById(id);
            var model = new SanphamDetail_EditModel
            {
                ID_sanpham = sanPham.ID_sanpham,
                Ten_Dienthoai = sanPham.Ten_Dienthoai,
                GiaBan = sanPham.GiaBan,
                Soluong = sanPham.Soluong,
                Kichthuoc = sanPham.Kichthuoc,
                Camera = sanPham.Camera,
                Mausac = sanPham.Mausac,
                Pin = sanPham.Pin,
                Manhinh = sanPham.Manhinh,
                BaoHanh = sanPham.BaoHanh,
                HinhAnh = sanPham.HinhAnh,
                ID_ThuongHieu = sanPham.ID_ThuongHieu
            };
            ViewBag.thuonghieu = _thuonghieuService.GetAll();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SanphamDetail_EditModel model)
        {
            if (ModelState.IsValid)
            {
                var sanpham = _sanphamService.GetById(model.ID_sanpham);
                sanpham.Ten_Dienthoai = model.Ten_Dienthoai;
                sanpham.Manhinh = model.Manhinh;
                sanpham.BaoHanh = model.BaoHanh;
                sanpham.Kichthuoc = model.Kichthuoc;
                sanpham.Mausac = model.Mausac;
                sanpham.Pin = model.Pin;
                sanpham.Camera= model.Camera;
                sanpham.ID_ThuongHieu = model.ID_ThuongHieu;
                if (model.Image != null)
                {
                    //var filename = Path.GetFileNameWithoutExtension(model.Image.FileName);
                    //var filepath = Path.Combine(_hostingEnvironment.WebRootPath, "Content/img", model.Image.FileName);
                    //using var filestream = new FileStream(filepath, FileMode.Create);
                    //model.Image.CopyTo(filestream);
                    //sanpham.HinhAnh = filename;
                    var path = _hostingEnvironment.WebRootPath;
                    var filepath = "Content/img/" + model.Image.FileName;
                    var fullpath = Path.Combine(path, filepath);
                    Uploadfile(model.Image, fullpath);
                    sanpham.HinhAnh = model.Image.FileName;
                }
                else
                {
                    sanpham.HinhAnh = "default-thumbnail.png";
                }
                await _sanphamService.UpdateAsSync(sanpham);
                return RedirectToAction("Index");
            }
            return View();
        }
        public void Uploadfile (IFormFile file,string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sanpham = _sanphamService.GetById(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            var model = new SanphamDeleteModel
            {
                ID_sanpham = sanpham.ID_sanpham,
                //Ten_dienthoai = sanpham.ten_dienthoai,
                //Giaban = sanpham.giaban,
                //Soluong = sanpham.soluong,
                //Kichthuoc = sanpham.kichthuoc,
                //Camera = sanpham.camera,
                //mausac = sanpham.mausac,
                //pin = sanpham.pin,
                //manhinh = sanpham.manhinh,
                //baohanh = sanpham.baohanh,
                //hinhanh = sanpham.hinhanh,
                //id_thuonghieu = sanpham.id_thuonghieu
            };
            ViewBag.thuonghieu = _thuonghieuService.GetById(sanpham.ID_ThuongHieu).Tenthuonghieu;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SanphamDeleteModel model)
        {
            var sanpham = _sanphamService.GetById(model.ID_sanpham);
            if (sanpham == null)
            {
                return NotFound();
            }
            await _sanphamService.DeleteById(sanpham.ID_sanpham);

            return  RedirectToAction("Index");
        }
    }
}


