using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Entity;
using admin_web_sell_phone.Models;
using admin_web_sell_phone.Service;
using Microsoft.AspNetCore.Mvc;

namespace admin_web_sell_phone.Controllers
{
    public class PhieunhapController : Controller
    {
        private IPhieunhapService _phieunhapService;
        private IWebHostEnvironment _hostingEnvironment;
        private INhacungcapService _nhacungcapService;
        private IChitietphieunhapService _chitietphieunhapService;
        private ISanphamService _sanphamService;
        private ApplicationDbContext _db;

        public PhieunhapController(IPhieunhapService phieunhapService, IWebHostEnvironment hostingEnvironment,
            INhacungcapService nhacungcapservice,IChitietphieunhapService chitietphieunhapService,
            ISanphamService sanphamService, ApplicationDbContext _context)
        {
            _phieunhapService = phieunhapService;
            _hostingEnvironment = hostingEnvironment;
            _nhacungcapService = nhacungcapservice;
            _chitietphieunhapService = chitietphieunhapService;
            _sanphamService = sanphamService;
            _db = _context;
        }
        public IActionResult Index()
        {
            var model = _phieunhapService.GetAll().Select(pn => new PhieuNhapModel
            {
                ID_Phieunhap = pn.ID_Phieunhap,
                Ngaynhap = pn.Ngay_nhap,
                Tonggia = pn.Tong_gia,
                ID_nhacungcap = pn.ID_NhaCungCap
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Nhacungung = _nhacungcapService.GetAll();
            ViewBag.Sanpham = _sanphamService.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var phieunhap = _phieunhapService.GetById(id);

            var model = new PhieuNhapModel
            {
                ID_Phieunhap = phieunhap.ID_Phieunhap,
                Ngaynhap = phieunhap.Ngay_nhap,
                Tonggia = phieunhap.Tong_gia,
                ID_nhacungcap = phieunhap.ID_NhaCungCap
            };
            ViewBag.Tennhacungcap = _nhacungcapService.GetById(model.ID_nhacungcap).Tennhacungcap;
            var ctpn = _chitietphieunhapService.GetById(model.ID_Phieunhap);
            var kqtvList = new List<ChitietphieunhapModel>();
            foreach (var ct in ctpn)
            {
                var kqtv = new ChitietphieunhapModel
                {
                    soluongnhap = ct.Soluongnhap,
                    ID_phieunhap = ct.ID_PhieuNhap,
                    ID_sanpham = ct.ID_SanPham,
                    gianhap = ct.Gianhap
                };
                kqtvList.Add(kqtv);
            }

            ViewBag.ChiTietPhieuNhap = kqtvList;
            var sanpham = new List<SanphamDetail_EditModel>();
            foreach(var ma in kqtvList)
            {
                var laysp = _sanphamService.GetById(ma.ID_sanpham);
                var kq = new SanphamDetail_EditModel
                {
                    ID_sanpham = laysp.ID_sanpham,
                    HinhAnh = laysp.HinhAnh,
                    Ten_Dienthoai = laysp.Ten_Dienthoai
                };
                sanpham.Add(kq);
            }
            ViewBag.Sanpham = sanpham;
            return View(model);
        }
    }
}
