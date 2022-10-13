using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosar2004.SajatOsztaly
{
    class Merkozes
    {
        private string hazai;

        public string Hazai
        {
            get { return hazai; }
            private set { hazai = value; }
        }

        private string vendeg;

        public string Vendeg
        {
            get { return vendeg; }
            private set { vendeg = value; }
        }
        private int hazaiPont;

        public int HazaiPont
        {
            get { return hazaiPont; }
            private set { hazaiPont = value; }
        }
        private int vendegPont;

        public int VendegPont
        {
            get { return vendegPont; }
            private set { vendegPont = value; }
        }
        private string helyszin;

        public string Helyszin
        {
            get { return helyszin; }
            private set { helyszin = value; }
        }

        private DateTime idopont;

        public DateTime Idopont
        {
            get { return idopont; }
            private set { idopont = value; }
        }

        public Merkozes(string sor)
        {
            string[] tmp = sor.Split(';');
            Hazai = tmp[0];
            Vendeg = tmp[1];
            HazaiPont = Convert.ToInt32(tmp[2]);
            VendegPont = Convert.ToInt32(tmp[3]);
            Helyszin = tmp[4];
            Idopont = Convert.ToDateTime(tmp[5]);
        }
    }
}
