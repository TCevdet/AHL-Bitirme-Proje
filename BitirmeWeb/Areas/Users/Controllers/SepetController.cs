using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using Bitirme.Models.ViewModels;
using Bitirme.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace BitirmeWeb.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class SepetController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public AlisverisSepetiVM AlisverisSepetiVM { get; set; }
        public SepetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            AlisverisSepetiVM = new()
            {
                AlisverisSepetiListe = _unitOfWork.AlisverisSepeti.GetAll(u => u.ApplicationUserId == userId,
            includeProperties: "Urun"),
                SiparisBaslik = new()
            };
            foreach (var sepet in AlisverisSepetiVM.AlisverisSepetiListe)
            {
                sepet.Fiyat = MiktaraGoreFiyat(sepet);
                AlisverisSepetiVM.SiparisBaslik.SiparisToplamTutar += (sepet.Fiyat * sepet.Adet);
            }

            return View(AlisverisSepetiVM);
        }

        public IActionResult Summary()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            AlisverisSepetiVM = new()
            {
                AlisverisSepetiListe = _unitOfWork.AlisverisSepeti.GetAll(u => u.ApplicationUserId == userId,
            includeProperties: "Urun"),
                SiparisBaslik = new()
            };

            AlisverisSepetiVM.SiparisBaslik.ApplicationUser=_unitOfWork.ApplicationUser.Get(u=>u.Id == userId);

            AlisverisSepetiVM.SiparisBaslik.Isim = AlisverisSepetiVM.SiparisBaslik.ApplicationUser.Isim;
            AlisverisSepetiVM.SiparisBaslik.TelefonNo = AlisverisSepetiVM.SiparisBaslik.ApplicationUser.TelefonNo;
            AlisverisSepetiVM.SiparisBaslik.Adres = AlisverisSepetiVM.SiparisBaslik.ApplicationUser.Adres;
            AlisverisSepetiVM.SiparisBaslik.Sehir = AlisverisSepetiVM.SiparisBaslik.ApplicationUser.Sehir;
            AlisverisSepetiVM.SiparisBaslik.Ilce = AlisverisSepetiVM.SiparisBaslik.ApplicationUser.Ilce;
            AlisverisSepetiVM.SiparisBaslik.PostaKodu = AlisverisSepetiVM.SiparisBaslik.ApplicationUser.PostaKodu;

            foreach (var sepet in AlisverisSepetiVM.AlisverisSepetiListe)
            {
                sepet.Fiyat = MiktaraGoreFiyat(sepet);
                AlisverisSepetiVM.SiparisBaslik.SiparisToplamTutar += (sepet.Fiyat * sepet.Adet);
            }
            return View(AlisverisSepetiVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            AlisverisSepetiVM.AlisverisSepetiListe = _unitOfWork.AlisverisSepeti.GetAll(u => u.ApplicationUserId == userId,
            includeProperties: "Urun");

            AlisverisSepetiVM.SiparisBaslik.SiparisZamani = System.DateTime.Now;
            AlisverisSepetiVM.SiparisBaslik.ApplicationUserId = userId;

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            foreach (var sepet in AlisverisSepetiVM.AlisverisSepetiListe)
            {
                sepet.Fiyat = MiktaraGoreFiyat(sepet);
                AlisverisSepetiVM.SiparisBaslik.SiparisToplamTutar += (sepet.Fiyat * sepet.Adet);
            }

            // İşlemi her durumda aynı şekilde yapabilirsiniz.
            AlisverisSepetiVM.SiparisBaslik.OdemeDurumu = SD.PaymentStatusDelayedPayment;
            AlisverisSepetiVM.SiparisBaslik.SiparisDurumu = SD.StatusApproved;

            _unitOfWork.SiparisBaslik.Add(AlisverisSepetiVM.SiparisBaslik);
            _unitOfWork.Save();

            foreach (var sepet in AlisverisSepetiVM.AlisverisSepetiListe)
            {
                SiparisDetay siparisDetay = new()
                {
                    UrunId = sepet.UrunId,
                    SiparisBaslikId = AlisverisSepetiVM.SiparisBaslik.Id,
                    Fiyat = sepet.Fiyat,
                    Adet = sepet.Adet
                };
                _unitOfWork.SiparisDetay.Add(siparisDetay);
                _unitOfWork.Save();
            }

            return RedirectToAction(nameof(OrderConfirmation), new { id = AlisverisSepetiVM.SiparisBaslik.Id });
        }



        //[HttpPost]
        //[ActionName("Summary")]
        //public IActionResult SummaryPOST()
        //{

        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

        //    AlisverisSepetiVM.AlisverisSepetiListe = _unitOfWork.AlisverisSepeti.GetAll(u => u.ApplicationUserId == userId,
        //    includeProperties: "Urun");

        //    AlisverisSepetiVM.SiparisBaslik.SiparisZamani=System.DateTime.Now;
        //    AlisverisSepetiVM.SiparisBaslik.ApplicationUserId = userId;


        //    ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

        //    foreach (var sepet in AlisverisSepetiVM.AlisverisSepetiListe)
        //    {
        //        sepet.Fiyat = MiktaraGoreFiyat(sepet);
        //        AlisverisSepetiVM.SiparisBaslik.SiparisToplamTutar += (sepet.Fiyat * sepet.Adet);
        //    }

        //    if (applicationUser.CompanyId.GetValueOrDefault()==0) {
        //        AlisverisSepetiVM.SiparisBaslik.OdemeDurumu = SD.PaymentStatusPending;
        //        AlisverisSepetiVM.SiparisBaslik.SiparisDurumu = SD.StatusPending;
        //    }


        //    else{
        //        AlisverisSepetiVM.SiparisBaslik.OdemeDurumu = SD.PaymentStatusDelayedPayment;
        //        AlisverisSepetiVM.SiparisBaslik.SiparisDurumu = SD.StatusApproved;
        //    }
        //    _unitOfWork.SiparisBaslik.Add(AlisverisSepetiVM.SiparisBaslik);
        //    _unitOfWork.Save();

        //    foreach (var sepet in AlisverisSepetiVM.AlisverisSepetiListe) {
        //        SiparisDetay siparisDetay = new()
        //        {
        //            UrunId = sepet.UrunId,
        //            SiparisBaslikId = AlisverisSepetiVM.SiparisBaslik.Id,
        //            Fiyat = sepet.Fiyat,
        //            Adet = sepet.Adet

        //        };
        //        _unitOfWork.SiparisDetay.Add(siparisDetay);
        //        _unitOfWork.Save();
        //    }
        //    if (applicationUser.CompanyId.GetValueOrDefault() == 0) {

        //    }

        //    return RedirectToAction(nameof(OrderConfirmation), new { id = AlisverisSepetiVM.SiparisBaslik.Id });
        //}

        public IActionResult OrderConfirmation(int id)
        {
            return View();
        }


        public IActionResult Plus(int cartId)
        {
            var cartFromDb = _unitOfWork.AlisverisSepeti.Get(u => u.Id == cartId, tracked:true);
            cartFromDb.Adet += 1;
            _unitOfWork.AlisverisSepeti.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.AlisverisSepeti.Get(u => u.Id == cartId, tracked:true);
            if (cartFromDb.Adet <= 1)
            {
                _unitOfWork.AlisverisSepeti.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Adet -= 1;
                _unitOfWork.AlisverisSepeti.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.AlisverisSepeti.Get(u => u.Id == cartId, tracked: true);

            _unitOfWork.AlisverisSepeti.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }



        private double MiktaraGoreFiyat(AlisverisSepeti alisverisSepeti)
        {
            if (alisverisSepeti.Adet <= 50)
            {
                return alisverisSepeti.Urun.Fiyat;
            }
            else
            {
                if (alisverisSepeti.Adet <= 100)
                {
                    return alisverisSepeti.Urun.Fiyat50;
                }
                else
                {
                    return alisverisSepeti.Urun.Fiyat100;
                }
            }

        }
    }
}
