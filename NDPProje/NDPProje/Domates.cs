using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPProje
{
    class Domates :IAtik
    {
        public int Hacim
        {
            get
            {
                return 150;
            }
        }

        public Image Image => throw new NotImplementedException();
    }
}
