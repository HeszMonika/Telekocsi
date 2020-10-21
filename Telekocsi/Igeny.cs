using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    class Igeny
    {
        public string Azonosito { get; set; }
        public string Indulas { get; set; }
        public string Cel { get; set; }
        public int Szemelyek { get; set; }


        public Igeny(string sor)
        {
            string[] a = sor.Split(';');
            Azonosito = a[0];
            Indulas = a[1];
            Cel = a[2];
            Szemelyek = Convert.ToInt32(a[3]);
        }
    }
}
