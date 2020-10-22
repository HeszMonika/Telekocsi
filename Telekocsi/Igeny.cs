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
        public string Utvonal { get; set; }


        public Igeny(string sor)
        {
            string[] a = sor.Split(';');
            Azonosito = a[0];
            Indulas = a[1];
            Cel = a[2];
            Szemelyek = Convert.ToInt32(a[3]);
            Utvonal = Indulas + "-" + Cel;
        }


        public int VanAuto(List<Auto> autok)
        {
            int i = 0;
            while (i < autok.Count && !(Utvonal == autok[i].Utvonal && Szemelyek <=autok[i].Ferohely))
            {
                i++;
            }
            if (i < autok.Count)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }
    }
}
