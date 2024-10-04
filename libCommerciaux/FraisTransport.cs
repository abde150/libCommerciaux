using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCommerciaux
{
    public class FraisTransport : NoteFrais
    {
        private int Nbkm;


        public FraisTransport(DateTime dateFrais, Commercial leCommercial, int Nbkm) : base (date, leCommercial)
        {
            this.Nbkm = Nbkm;
        }
    }
}
