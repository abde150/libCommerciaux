namespace libCommerciaux
{
    public class Commercial
    {
        private string nom;
        private string prenom;
        private char CatPro;
        private int PuissanceVec;
        private List<NoteFrais> NotedeFrais;


        public Commercial(string nom, string prenom, char CatPro, int PuissanceVec)
        {
            this.nom = nom; 
            this.prenom = prenom;
            this.CatPro = CatPro;
            this.PuissanceVec = PuissanceVec;
            NotedeFrais = new List<NoteFrais>();
        }

        public string getNom()
        {
            return nom;
        }

        public string getPrenom() 
        { 
            return prenom;
        }

        public char getCatPro() 
        {
            return CatPro;
        }
        public int getPuissanceVec() 
        {
           return PuissanceVec;
        }

        public void AjoutFrais(NoteFrais a)
        {
            NotedeFrais.Add(a);
        }

        public override string ToString()
        {
            return $"{prenom} {nom}, Catégorie Profesionnelle : {CatPro}, Puissance du véhicule : {PuissanceVec}";
        }

        public List<NoteFrais> getMesNoteFrais()
        {
            return NotedeFrais;
        }

    }
}
