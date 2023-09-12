using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakimMVC.Quiz.Core.Contetxt;
using TakimMVC.Quiz.DAL.Interface;
using TakimMVC.Quiz.DTO;
using TakimMVC.Quiz.Entities;

namespace TakimMVC.Quiz.DAL.Concrete
{
    public class KisiDAL : IKisiDAL
    {
        private readonly MyContext _myContext;
        //private readonly UnvanSayisiDAL _uDal;
        public KisiDAL(MyContext myContext)
        {
            _myContext = myContext;
            //_uDal = uDal;

        }
        public void Add(Kisi kisi)
        {
            //todo yeni takım eklerken burada hata veriyor. Foreign keyli bir hata. yeni takım ekleme olayına bak
            //metod contollerdan çağırılarak, controllerda direkt bu metod işletilip duruma göre ekleme yapılmalı

            //int a = _uDal.AnalistAdet().Count();
            //int l = _uDal.LiderAdet().Count();
            //int d = _uDal.DeveloperAdet().Count();
            //int t = _uDal.TesterAdet().Count();

            var takim1 = _myContext.Takim.SingleOrDefault(a => a.TakimIsim == "Poyraz");
            var takim2 = _myContext.Takim.SingleOrDefault(a => a.TakimIsim == "Karayel");
            var takim3 = _myContext.Takim.SingleOrDefault(a => a.TakimIsim == "Lodos");

           

            if (true) 
            {
                // takım uygun değil. ekleme yapmadan hata dönmeli

            }
            else
            {
                //takım uygun demek ve burada ekleme yapılacak
                _myContext.Add(kisi);
                _myContext.SaveChanges();
            }          
        }

        public List<KisiDTO> GetAll()
        {
            var result = from kisi in _myContext.Kisi
                         join takim in _myContext.Takim on kisi.TakimID equals takim.TakimID
                         join unvan in _myContext.Unvan on kisi.UnvanID equals unvan.UnvanID
                         select new KisiDTO
                         {
                             KisiID = kisi.KisiID,
                             Isim = kisi.Isim,
                             Soyisim = kisi.Soyisim,
                             TakimIsim = takim.TakimIsim,
                             UnvanIsim = unvan.UnvanIsim
                         };

            return result.ToList();
        }
    }
}
