using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPProje
{
    class CamKutusu : IDolabilen, IAtikKutusu
    {
            int CamKapasite;
            int CamDoluHacim;

        public int Kapasite
        {
            get
            {
                return CamKapasite;
            }
            set
            {
                CamKapasite = value;
            }
        }
        public int DoluHacim
        {
            get { return CamDoluHacim; }
            set { CamDoluHacim = value; }
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
                return 600;
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
