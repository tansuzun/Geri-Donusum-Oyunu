using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPProje
{
    class OrganikAtıkKutusu : IDolabilen, IAtikKutusu
    {
        int OrganikKapasite;
        int OrganikDoluHacim;

        public int Kapasite 
        {
            get
            {
                return OrganikKapasite;
            }
            set
            {
                OrganikKapasite = value;
            }
        }
        public int DoluHacim
        {
            get { return OrganikDoluHacim; }
            set { OrganikDoluHacim = value; }
        }

        public int DolulukOrani
        {
            get
            {
                return (100 * DoluHacim) / Kapasite;
            }
        }

        public int bosaltmaPuani => throw new NotImplementedException();

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
