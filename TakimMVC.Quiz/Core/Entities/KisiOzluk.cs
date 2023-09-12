using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakimMVC.Quiz.Entities
{
    public class KisiOzluk
    {
        public int  KisiOzlukID { get; set; }
        public string TC { get; set; }
        public string Telefom { get; set; }
        public DateTime DogumTarihi { get; set; }

        public Kisi Kisi { get; set; }
    }
}
