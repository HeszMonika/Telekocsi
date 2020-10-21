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


        static void BeolvasAutok()
        {
            StreamReader sr = new StreamReader("autok.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Autok.Add(new Auto(sr.ReadLine()));
            }
            sr.Close();
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
            List<string> utvonalak = new List<string>();
            foreach (var a in Autok)
            {

            }
        }


        static void BeolvasIgenyek()
        {
            StreamReader sr = new StreamReader("igenyek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Igenyek.Add(new Igeny(sr.ReadLine()));
            }
            sr.Close();


            foreach (var a in Autok)
            {
                foreach (var i in Igenyek)
                {
                    if (i.Indulas == a.Indulas && i.Cel == a.Cel && i.Szemelyek == a.Ferohely)
                    {
                        Console.WriteLine($"{i.Azonosito} => {a.Rendszam}");
                    }
                }
            }
        }


        static void HatodikFeladat()
        {
            StreamWriter sw = new StreamWriter("utasuzenetek.txt");
            foreach (var a in Autok)
            {
                foreach (var i in Igenyek)
                {
                    if (a.Ferohely == 0)
                    {
                        sw.WriteLine("{0}: Sajnos nem sikerült autót találni.", i.Azonosito);
                    }
                    else
                    {
                        sw.WriteLine("{0}: Rendszám: {1}, Telefonszám: {2}", i.Azonosito, a.Rendszam, a.Telefonszam);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            BeolvasAutok();
            foreach (var a in Autok)
            {
                Console.WriteLine($"{a.Indulas}, {a.Cel}, {a.Rendszam}, {a.Telefonszam}, {a.Ferohely}");
            }

            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            BeolvasIgenyek();
            HatodikFeladat();


            Console.ReadKey();
        }
    }
}
