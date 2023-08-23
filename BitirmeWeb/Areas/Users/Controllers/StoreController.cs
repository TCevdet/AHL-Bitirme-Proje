
using Bitirme.DataAccess.Repository;
using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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
            AlisverisSepeti sepet = new AlisverisSepeti()
            {
                    Urun= _unitOfWork.Urun.Get(u => u.Id == urunId, includeProperties: "Kategori"),
                    Miktar=1,
                    UrunId=urunId
                    
            };
            return View(sepet);
        }

        [HttpPost]
        [Authorize]
        public IActionResult UrunDetay(AlisverisSepeti alisverisSepeti)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId=claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            alisverisSepeti.ApplicationUserId = userId;

            AlisverisSepeti sepetFromDb = _unitOfWork.AlisverisSepeti.Get(u=>u.ApplicationUserId == userId &&
            u.UrunId==alisverisSepeti.UrunId);

            if (sepetFromDb != null)
            {
                sepetFromDb.Miktar += alisverisSepeti.Miktar;
                _unitOfWork.AlisverisSepeti.Update(sepetFromDb);
            }
            else
            {
                _unitOfWork.AlisverisSepeti.Add(alisverisSepeti);
            }
            TempData["success"] = "Sepetiniz güncellendi";

            _unitOfWork.AlisverisSepeti.Add(alisverisSepeti);
            _unitOfWork.Save();
            return View();

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