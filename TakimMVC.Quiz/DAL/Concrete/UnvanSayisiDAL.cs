using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakimMVC.Quiz.Core.Contetxt;
using TakimMVC.Quiz.DAL.Interface;
using TakimMVC.Quiz.DTO;

namespace TakimMVC.Quiz.DAL.Concrete
{
    public class UnvanSayisiDAL  : IUnvanSayisiDAL
    {
        private readonly MyContext _mycontext;
        public UnvanSayisiDAL(MyContext mycontext)
        {
            _mycontext = mycontext;
        }
        public List<UnvanSayisiDTO> AnalistAdet()
        {
            var query = from kisi in _mycontext.Kisi
                        join takim in _mycontext.Takim on kisi.TakimID equals takim.TakimID
                        join unvan in _mycontext.Unvan on kisi.UnvanID equals unvan.UnvanID
                        where unvan.UnvanIsim == "Analist"
                        group new { takim, unvan } by new { takim.TakimIsim, unvan.UnvanIsim } into grouped
                        orderby grouped.Key.UnvanIsim
                        select new UnvanSayisiDTO
                        {
                            TakimIsim = grouped.Key.TakimIsim,
                            AnalistSayisi = grouped.Count()
                        };

            var result = query.ToList();
            return result;
        }

        public List<UnvanSayisiDTO> DeveloperAdet()
        {
            var query = from kisi in _mycontext.Kisi
                        join takim in _mycontext.Takim on kisi.TakimID equals takim.TakimID
                        join unvan in _mycontext.Unvan on kisi.UnvanID equals unvan.UnvanID
                        where unvan.UnvanIsim == "Developer"
                        group new { takim, unvan } by new { takim.TakimIsim, unvan.UnvanIsim } into grouped
                        orderby grouped.Key.UnvanIsim
                        select new UnvanSayisiDTO
                        {
                            TakimIsim = grouped.Key.TakimIsim,
                            DeveloperSayisi = grouped.Count()
                        };

            var result = query.ToList();
            return result;

        }

        public List<UnvanSayisiDTO> LiderAdet()
        {
            var query = from kisi in _mycontext.Kisi
                        join takim in _mycontext.Takim on kisi.TakimID equals takim.TakimID
                        join unvan in _mycontext.Unvan on kisi.UnvanID equals unvan.UnvanID
                        where unvan.UnvanIsim == "Takım Lideri"
                        group new { takim, unvan } by new { takim.TakimIsim, unvan.UnvanIsim } into grouped
                        orderby grouped.Key.UnvanIsim
                        select new UnvanSayisiDTO
                        {
                            TakimIsim = grouped.Key.TakimIsim,
                            LiderSayisi = grouped.Count()
                        };

            var result = query.ToList();
            return result;
        }

        public List<UnvanSayisiDTO> TesterAdet()
        {
            var query = from kisi in _mycontext.Kisi
                        join takim in _mycontext.Takim on kisi.TakimID equals takim.TakimID
                        join unvan in _mycontext.Unvan on kisi.UnvanID equals unvan.UnvanID
                        where unvan.UnvanIsim == "Tester"
                        group new { takim, unvan } by new { takim.TakimIsim, unvan.UnvanIsim } into grouped
                        orderby grouped.Key.UnvanIsim
                        select new UnvanSayisiDTO
                        {
                            TakimIsim = grouped.Key.TakimIsim,
                            TesterSayisi = grouped.Count()
                        };

            var result = query.ToList();
            return result;
        }
    }
}
