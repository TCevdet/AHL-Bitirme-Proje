using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class SiparisController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public SiparisController(IUnitOfWork unitOfWork)
        {
                _unitOfWork=unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region APICALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<SiparisBaslik> objSiparisBasliks = _unitOfWork.SiparisBaslik.GetAll(includeProperties: "ApplicationUser").ToList();
            return Json(new { data = objSiparisBasliks });
        }

        

            #endregion
        }
    }
