using Kosar2004.SajatOsztaly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosar2004
{
    class Program
    {
        static List<Merkozes> merkozesek = new List<Merkozes>();
        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat("Real Madrid");
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat("2004.11.21");
            HetedikFeladat();

            Console.ReadKey();
        }

        private static void HetedikFeladat()
        {
            Console.WriteLine("7. feladat: ");
            Dictionary<string, int> stadionok = StadionokHasznalata();

            foreach (var x in stadionok)
            {
                if (x.Value > 20)
                {
                    Console.WriteLine($"\t{x.Key}: {x.Value}");
                }
            }
        }

        private static Dictionary<string, int> StadionokHasznalata()
        {
            Dictionary<string, int> stadionok = new Dictionary<string, int>();
            foreach (var x in merkozesek)
            {
                if (stadionok.ContainsKey(x.Helyszin))
                {
                    stadionok[x.Helyszin]++;
                }
                else
                {
                    stadionok.Add(x.Helyszin, 1);
                }
            }

            return stadionok;
        }

        private static void HatodikFeladat(string keresettIdopont)
        {
            Console.WriteLine("6. feladat: ");
            foreach (var x in merkozesek)
            {
                if (Convert.ToDateTime(keresettIdopont) == x.Idopont)
                {
                    Console.WriteLine($"\t{x.Hazai}-{x.Vendeg} ({x.HazaiPont}:{x.VendegPont})");
                }
                
            }
        }

        private static void OtodikFeladat()
        {
            Console.Write("5. feladat: barcelonai csapat neve: ");
            string csapatNev = string.Empty;
            foreach (var x in merkozesek)
            {
                if (csapatNev == string.Empty && x.Hazai.Contains("Barcelona"))
                {
                    csapatNev = x.Hazai;
                }
            }
            Console.WriteLine(csapatNev);
        }

        private static void NegyedikFeladat()
        {
            Console.Write("4. feladat: Volt döntetlen? ");
            
            int i = 0;
            while (i < merkozesek.Count && merkozesek[i].HazaiPont != merkozesek[i].VendegPont)
            {
                i++;
            }
            if (i == merkozesek.Count)
            {
                Console.WriteLine("nem");
            }
            else
            {
                Console.WriteLine("igen");
            }
        }

        private static void HarmadikFeladat(string keresettCsapat)
        {
            Console.Write($"3. feladat: {keresettCsapat}: ");
            int hazai = 0;
            int vendeg = 0;
            foreach (var x in merkozesek)
            {
                if (x.Hazai == keresettCsapat)
                {
                    hazai++;
                }
                if (x.Vendeg == keresettCsapat)
                {
                    vendeg++;
                }
            }
            Console.WriteLine($"Hazai: {hazai}, Idegen: {vendeg}");
        }

        private static void MasodikFeladat()
        {
            using (StreamReader sr = new StreamReader("Adatfajl/eredmenyek.csv"))
            {
                sr.ReadLine(); //első sor skip
                while (!sr.EndOfStream)
                {
                    merkozesek.Add(new Merkozes(sr.ReadLine()));
                }

            }
        }
    }
}
