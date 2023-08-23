using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using Bitirme.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BitirmeWeb.Areas.Users.Controllers
{
    [Area("users")]
    [Authorize]
    public class SepetController : Controller { 

        private readonly IUnitOfWork _unitOfWork;
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
                AlisverisSepetiList = _unitOfWork.AlisverisSepeti.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "Urun")
            };
            foreach (var sepet in AlisverisSepetiVM.AlisverisSepetiList)
            {
                sepet.Fiyat = MiktarUzerindenFiyat(sepet);
                AlisverisSepetiVM.SiparisTutar += (sepet.Fiyat * sepet.Miktar);
            }

            return View(AlisverisSepetiVM);
        }
        public IActionResult Plus(int sepetId) 
        {
            var sepetFromDb = _unitOfWork.AlisverisSepeti.Get(u => u.Id == sepetId);
            sepetFromDb.Miktar += 1;
            _unitOfWork.AlisverisSepeti.Update(sepetFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int sepetId)
        {
            var sepetFromDb = _unitOfWork.AlisverisSepeti.Get(u => u.Id == sepetId);
            //sepette miktarı 1 olan ürün "0" olarak görünmemeli, bu yüzden miktar 1den küçükse tamamen atıyorum
            if (sepetFromDb.Miktar<=1)
            {
                //sepetten çıkar
                _unitOfWork.AlisverisSepeti.Remove(sepetFromDb);
            }
            else
            {
                sepetFromDb.Miktar -= 1;
                _unitOfWork.AlisverisSepeti.Update(sepetFromDb);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //Sepetten Sİl--
        public IActionResult Remove(int sepetId)
        {
            var sepetFromDb = _unitOfWork.AlisverisSepeti.Get(u => u.Id == sepetId);
            _unitOfWork.AlisverisSepeti.Remove(sepetFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        //---


        private double MiktarUzerindenFiyat(AlisverisSepeti alisverisSepeti)
        {
            if (alisverisSepeti.Miktar<=50)
            {
                return alisverisSepeti.Urun.Fiyat;
            }
            else
            {
                if (alisverisSepeti.Miktar <= 100)
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
