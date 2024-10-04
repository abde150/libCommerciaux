using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libCommerciaux;

namespace libCommerciaux
{
    public class ServiceCommercial
    {
        private List<Commercial> Commerciaux;

        public ServiceCommercial(List<Commercial> Commerciaux)
        {
            Commerciaux = new List<Commercial>();

        }

        public void ajouterCommercial(Commercial a)
        {
            Commerciaux.Add(a);
        }

        public int nbFraisNonRembourses()
        {
            int TotalNonRembourses = 0;

            foreach (Commercial a in Commerciaux)
            {
                foreach (NoteFrais n in a.getMesNoteFrais())
                {
                    if (!n.getEstRembourse())
                    {
                        TotalNonRembourses++;
                    }

                }
            }
            return TotalNonRembourses;
        }

    }

}
