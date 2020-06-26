using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPProje
{
    class MetalKutusu : IDolabilen,IAtikKutusu
    {
        int MetalKapasite;
        int MetalDoluHacim;
        public int Kapasite
        {
            get
            {
                return MetalKapasite;
            }
            set
            {
                MetalKapasite = value;
            }
        }
        public int DoluHacim
        {
            get { return MetalDoluHacim; }
            set { MetalDoluHacim = value; }
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
                return 800;
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
