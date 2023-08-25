
using Bitirme.DataAccess.Data;
using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using Bitirme.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class KategoriController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public KategoriController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Kategori> objKategoriList = _unitOfWork.Kategori.GetAll().ToList();
            return View(objKategoriList);
        }


        //GET KATEGORİ EKLE Metodu
        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(Kategori obj)
        {
            if (obj.Ad == obj.Siparis.ToString())
            {
                ModelState.AddModelError("Ad", "Kategori Adı Siparişle Aynı Olamaz.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Kategori.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Kategori Oluşturuldu";
                return RedirectToAction("Index");
            }
            return View();

        }

        //GET-POST DUZENLE

        public IActionResult KategoriDuzenle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kategori? kategoriFromDb = _unitOfWork.Kategori.Get(u => u.Id == id);
            if (kategoriFromDb == null)
            {
                return NotFound();
            }

            return View(kategoriFromDb);

        }
        [HttpPost]
        public IActionResult KategoriDuzenle(Kategori obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Kategori.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Kategori Düzenlendi";
                return RedirectToAction("Index");
            }
            return View();

        }

        //DELETE--- 1. Kategoriden Getir, 2. http action Sil

        public IActionResult KategoriSil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kategori? kategoriFromDb = _unitOfWork.Kategori.Get(u => u.Id == id);

            if (kategoriFromDb == null)
            {
                return NotFound();
            }

            return View(kategoriFromDb);

        }
        [HttpPost, ActionName("KategoriSil")]
        public IActionResult KategoriSilPOST(int? id)
        {
            Kategori? obj = _unitOfWork.Kategori.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Kategori.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kategori Silindi";
            return RedirectToAction("Index");

        }


    }
}

