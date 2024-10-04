namespace libCommerciaux
{
    public class NoteFrais
    {
        private int numero;
        private DateTime DateFrais;
        private double montantARembourser;
        private Commercial leCommercial;
        private bool Rembourse;
    
    public NoteFrais(DateTime dateFrais, Commercial leCommercial)
        {
            this.numero = numero;
            this.DateFrais = DateFrais;
            this.Rembourse = false;
            this.montantARembourser = montantARembourser;
        }

      public int getNumero() 
        {
            return numero;
        }

       public DateTime getDateFrais() 
        {
            return DateFrais;
        }

       public double getmontantARembourser()
        {
            return montantARembourser;
        }
       public double calculMontantARembourser()
        {
            return montantARembourser;
        }

       public bool getEstRembourse()
        {
          return true;
        }


        public override string ToString()
        {
            return $"{numero}, {DateFrais}, {montantARembourser}, {leCommercial}";
        }




















    }
}