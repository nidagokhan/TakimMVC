using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakimMVC.Quiz.DTO
{
    public class UnvanSayisiDTO
    {
        public int TakimID { get; set; }
        public string TakimIsim { get; set; }

        public int LiderSayisi { get; set; }

        public int AnalistSayisi { get; set; }

        public int DeveloperSayisi { get; set; }

        public int TesterSayisi { get; set; }
    }
}
