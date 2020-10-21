using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekocsi
{
    class Program
    {
        static List<Auto> Autok = new List<Auto>();
        static List<Igeny> Igenyek = new List<Igeny>();


        static void Beolvasas()
        {
            StreamReader sr = new StreamReader("autok.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Autok.Add(new Auto(sr.ReadLine()));
            }
            sr.Close();

            StreamReader file = new StreamReader("igenyek.csv");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                Igenyek.Add(new Igeny(file.ReadLine()));
            }
            file.Close();


        }


        static void MasodikFeladat()
        {
            Console.WriteLine("2. feladat: ");
            Console.WriteLine("   {0} autós hirdet fuvart.", Autok.Count);
        }


        static void HarmadikFeladat()
        {
            Console.WriteLine("3. feladat: ");
            int db = 0;
            foreach (var a in Autok)
            {
                if (a.Indulas == "Budapest" && a.Cel == "Miskolc")
                {
                    db = db + a.Ferohely;
                }
            }
            Console.WriteLine("   Összesen {0} férőhelyet hirdettek az autósok Budapestről Miskolcra.", db);
        }


        static void NegyedikFeladat()
        {
            //Létrehozzu az Auto osztályba az Utvonal-at.
            Console.WriteLine("4. feladat:");
            //Dictionary<string, int> utvonalak = new Dictionary<string, int>();
            //foreach (var a in Autok)
            //{
            //    if (!utvonalak.ContainsKey(a.Utvonal))
            //    {
            //        utvonalak.Add(a.Utvonal, a.Ferohely);
            //    }
            //    else
            //    {
            //        utvonalak[a.Utvonal] = utvonalak[a.Utvonal] + a.Ferohely;
            //    }
            //}
            int max = 0;
            string utvonal = "";
            //foreach (var u in utvonalak)
            //{
            //    if (u.Value > max)
            //    {
            //        max = u.Value;
            //        utvonal = u.Key;
            //    }
            //}

            //Console.WriteLine($"   {max} - {utvonal}");

            var utvonalak = from a in Autok orderby a.Utvonal group a by a.Utvonal into temp select temp;

            foreach (var ut in utvonalak)
            {
                //Console.WriteLine($"{ut.Key} -> {ut.Count()}");
                int fh = ut.Sum(x => x.Ferohely);
                if (max < fh)
                {
                    max = fh;
                    utvonal = ut.Key;
                }
            }
            Console.WriteLine($"   {max} - {utvonal}");


            Console.ReadKey();
        }


        static void OtodikFeladat()
        {
            Console.WriteLine("5. feladat:");
            foreach (var igeny in Igenyek)
            {
                int i = 0;
                while (i < Autok.Count && !(igeny.Indulas == Autok[i].Indulas
                    && igeny.Cel == Autok[i].Cel && igeny.Szemelyek <= Autok[i].Ferohely))
                {
                    i++;
                }
                if (i < Autok.Count)
                {
                    Console.WriteLine($"{igeny.Azonosito} => {Autok[i].Rendszam}");
                }
            }
        }


        static void HatodikFeladat()
        {
            StreamWriter sw = new StreamWriter("utasuzenetek.txt");
            foreach (var igeny in Igenyek)
            {
                int i = 0;
                while (i < Autok.Count && !(igeny.Indulas == Autok[i].Indulas
                    && igeny.Cel == Autok[i].Cel && igeny.Szemelyek <= Autok[i].Ferohely))
                {
                    i++;
                }
                if (i < Autok.Count)
                {
                    sw.WriteLine($"{igeny.Azonosito}: Rendszám: {Autok[i].Rendszam}, Telefonszám: {Autok[i].Telefonszam}");
                }
            }
            sw.Close();
        }


        static void Main(string[] args)
        {
            Beolvasas();
            foreach (var a in Autok)
            {
                Console.WriteLine($"{a.Indulas}, {a.Cel}, {a.Rendszam}, {a.Telefonszam}, {a.Ferohely}");
            }

            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();


            Console.ReadKey();
        }
    }
}
