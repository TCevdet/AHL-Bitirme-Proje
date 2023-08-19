
using Bitirme.DataAccess.Repository;
using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitirmeWeb.Areas.Users.Controllers
{
    [Area("Users")]
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public StoreController(ILogger<StoreController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult StoreIndex()
        {
            IEnumerable<Urun> urunList = _unitOfWork.Urun.GetAll(includeProperties: "Kategori");
            return View(urunList);
        }

        public IActionResult UrunDetay(int urunId)
        {
            Urun urun = _unitOfWork.Urun.Get(u=>u.Id==urunId, includeProperties: "Kategori");
            return View(urun);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}