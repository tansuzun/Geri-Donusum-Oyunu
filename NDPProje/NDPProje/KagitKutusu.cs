using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPProje
{
    class KagitKutusu : IDolabilen, IAtikKutusu
    {
        int KagitKapasite;
        int KagitDoluHacim;

        public int Kapasite
        {
            get
            {
                return KagitKapasite;
            }
            set
            {
                KagitKapasite = value;
            }
        }
        public int DoluHacim
        {
            get { return KagitDoluHacim; }
            set { KagitDoluHacim = value; }
        }
        public int DolulukOrani
        {
            get
            {
                return (100 * DoluHacim) / Kapasite;
            }
        }

        public int bosaltmaPuani
        {
            get
            {
                return 1000;
            }
        }

        public bool Bosalt()
        {
            if (DolulukOrani > 75)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Ekle(IAtik atik)
        {
            throw new NotImplementedException();
        }
    }

}
