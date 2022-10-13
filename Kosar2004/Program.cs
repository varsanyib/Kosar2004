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

            Console.ReadKey();
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
