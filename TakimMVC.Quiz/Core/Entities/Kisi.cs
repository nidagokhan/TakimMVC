using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakimMVC.Quiz.Entities
{
    public class Kisi
    {
        public int KisiID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public int TakimID { get; set; }
        public int UnvanID { get; set; }
        public KisiOzluk KisiOzluk { get; set; }
        public Takim Takim { get; set; }
    }
}
