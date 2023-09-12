using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;
//using System.Web.Mvc;
using TakimMVC.Quiz.DAL.Interface;
using TakimMVC.Quiz.DTO;
using TakimMVC.Quiz.Entities;

namespace TakimMVC.Quiz.Controllers
{
    public class TakimController : Controller
    {
        private readonly IKisiDAL _kDal;
        private readonly ITakimDAL _tDal;

        public TakimController(IKisiDAL kDal, ITakimDAL tDal)
        {
            _kDal = kDal;
            _tDal= tDal;
        }

        //1.Aşama Navbardan Kişi sekmesi seçilerek kişi listesi sıralanır. açılan sayfada yeni kişi ekleme butonu ile db yeni kişi kaydetme işlemi yapılır
        public IActionResult Index()
        {
            var result=_kDal.GetAll();
            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Kisi kisi)
        {
            _kDal.Add(kisi);
            return RedirectToAction("Index");
        }

        //2. aşama yine Navbardan Takım kısmı seçilerek takimlar listelenir. detay gör linki tıklanarak takımdaki kişler listelenir.

        public ActionResult Takim()
        {
            var result=_tDal.GetAll();
            return View(result);
        }
        public ActionResult TakimID(int id)
        {
            var result = _tDal.GetById(id);
            return View(result);
        }

        public ActionResult AddTakim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTakim(Takim takim)
        {
            _tDal.Add(takim);
            return RedirectToAction("Takim");
        }
    }
}
