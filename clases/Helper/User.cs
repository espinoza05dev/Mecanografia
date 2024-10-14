using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECANOGRAFIA.clases.Helper
{
    public class User
    {
        public int dias_seguido { get; set; }
        public string tabla { get; set; }
        public string campos { get; set;}
        public string valores { get; set;}
        public string condicion  { get; set; }
        public string msg { get; set; }
    }
}
