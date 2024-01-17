using BanVali.Models;
using BanVali.Models.FE;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BanVali.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? pageIndex)
        {
            int pageSize = 16; // Số sản phẩm trên mỗi trang
            var products = db.TDanhMucSps.AsQueryable();

            return View(await PaginatedList<TDanhMucSp>.CreateAsync(products, pageIndex ?? 1, pageSize));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ListProducts(string maLoai, int pageIndex = 1, int pageSize = 8)
        {
            var query = db.TDanhMucSps.Where(p => p.MaLoai == maLoai).AsQueryable();

            var paginatedProducts = await PaginatedList<TDanhMucSp>.CreateAsync(query, pageIndex, pageSize);

            return View(paginatedProducts);
        }
        //string
        public IActionResult Details(string maSp)
        {
            var product = db.TDanhMucSps.SingleOrDefault(p => p.MaSp == maSp);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Images = db.TAnhSps.Where(a => a.MaSp == maSp).ToList();

            return View(product);
        }
    }
}

