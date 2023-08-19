
using Bitirme.DataAccess.Data;
using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using Bitirme.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BitirmeWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UrunController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Urun> objUrunList = _unitOfWork.Urun.GetAll(includeProperties: "Kategori").ToList();

            return View(objUrunList);
        }



        //Ürün EKLE-DÜZENLE
        public IActionResult Upsert(int? id)
        {
            UrunVM urunVM = new()
            {
                KategoriList = _unitOfWork.Kategori.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Ad,
                    Value = u.Id.ToString()
                }),
                Urun = new Urun()
            };
            if (id == null || id == 0)
            {   //Ürün ekle
                return View(urunVM);
            }
            else
            {
                //düzenle fonksiyonunu else ile tanımlıyoruz
                urunVM.Urun = _unitOfWork.Urun.Get(u => u.Id == id);
                return View(urunVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(UrunVM urunVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    //yeniden yüklediğimiz resme rastgele bir isim veriyoruz
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string urunPath = Path.Combine(wwwRootPath, @"resimler\urunler");


                    if (!string.IsNullOrEmpty(urunVM.Urun.ResimUrl))
                    {
                        //eski resmi siliyoruz
                        var eskiResimPath = Path.Combine(wwwRootPath, urunVM.Urun.ResimUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(eskiResimPath))
                        {
                            System.IO.File.Delete(eskiResimPath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(urunPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    urunVM.Urun.ResimUrl = @"\resimler\urunler\" + fileName;
                }

                if (urunVM.Urun.Id == 0)
                {
                    _unitOfWork.Urun.Add(urunVM.Urun);
                }
                else
                {
                    _unitOfWork.Urun.Update(urunVM.Urun);
                }


                //_unitOfWork.Urun.Add(urunVM.Urun); << ürün düzeltmede hata verdi fazla satırı kaldırdım.
                _unitOfWork.Save();
                TempData["success"] = "Ürün Oluşturuldu";
                return RedirectToAction("Index");
            }
            else
            {
                urunVM.KategoriList = _unitOfWork.Kategori.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Ad,
                    Value = u.Id.ToString()
                });
                return View(urunVM);
            }

        }

        //GET-POST DUZENLE

        //DELETE--- 1. Urunden Getir, 2. http action Sil

        //public IActionResult UrunSil(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Urun? UrunFromDb = _unitOfWork.Urun.Get(u => u.Id == id);

        //    if (UrunFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(UrunFromDb);

        //}
        //[HttpPost, ActionName("UrunSil")]
        //public IActionResult UrunSilPOST(int? id)
        //{
        //    Urun? obj = _unitOfWork.Urun.Get(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Urun.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Urun Silindi";
        //    return RedirectToAction("Index");

        //}
        #region APICALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Urun> objUrunList = _unitOfWork.Urun.GetAll(includeProperties: "Kategori").ToList();
            return Json(new { data = objUrunList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)

        {
            var silinecekUrun = _unitOfWork.Urun.Get(u => u.Id == id);
            if (silinecekUrun == null)
            {
                return Json(new { success = false, message = "Silerken bir hata oluştu" });
            }
            var eskiResimPath = Path.Combine(_webHostEnvironment.WebRootPath,
                silinecekUrun.ResimUrl.TrimStart('\\'));

            if (System.IO.File.Exists(eskiResimPath))
            {
                System.IO.File.Delete(eskiResimPath);
            }

            _unitOfWork.Urun.Remove(silinecekUrun);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Başarıyla Silindi" });



            #endregion


        }
    }
}

