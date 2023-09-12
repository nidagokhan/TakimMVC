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
    public class TakimDAL : ITakimDAL
    {
        private readonly MyContext _mycontext;

        public TakimDAL(MyContext mycontext)
        {
            _mycontext = mycontext;
        }
        public void Add(Takim takim)
        {
            try
            {
                _mycontext.Add(takim);
                _mycontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TakimDTO> GetAll()
        {
            var takim = _mycontext.Takim.ToList();
            var result = takim.Select(a => new TakimDTO
            {
                TakimID = a.TakimID,
                TakimIsim = a.TakimIsim
            }).ToList();

            return result;
        }

        public List<TakimGrupDTO> GetById(int id)
        {
            var result = from takim in _mycontext.Takim
                        join kisi in _mycontext.Kisi on takim.TakimID equals kisi.TakimID
                        join unvan in _mycontext.Unvan on kisi.UnvanID equals unvan.UnvanID
                        where takim.TakimID == id
                        select new TakimGrupDTO
                        {
                            TakimID= kisi.TakimID,
                            TakimIsim=takim.TakimIsim,
                            Isim=kisi.Isim,
                            Soyisim=kisi.Soyisim,
                            UnvanIsim=unvan.UnvanIsim
                        };           
            return result.ToList();
        }
    }
}
