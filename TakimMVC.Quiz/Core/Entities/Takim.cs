using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakimMVC.Quiz.Entities
{
    public class Takim
    {
        public int TakimID { get; set; }
        public string TakimIsim { get; set; }
        public List<Kisi> Kisis { get; set; }
    }
}
