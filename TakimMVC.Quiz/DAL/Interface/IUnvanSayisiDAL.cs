using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakimMVC.Quiz.DTO;

namespace TakimMVC.Quiz.DAL.Interface
{
    public interface IUnvanSayisiDAL
    {
        public List<UnvanSayisiDTO> LiderAdet();
        public List<UnvanSayisiDTO> AnalistAdet();
        public List<UnvanSayisiDTO> DeveloperAdet();
        public List<UnvanSayisiDTO> TesterAdet();
    }
}
