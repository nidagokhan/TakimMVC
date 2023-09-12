using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakimMVC.Quiz.Entities
{
    public class Unvan
    {
        public int UnvanID { get; set; }
        public string UnvanIsim { get; set; }
        public List<Kisi> Kisis { get; set; }
    }
}
