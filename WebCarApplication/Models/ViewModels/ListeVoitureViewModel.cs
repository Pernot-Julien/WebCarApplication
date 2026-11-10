namespace WebCarApplication.Models.ViewModels
{
    public class ListeVoitureViewModel
    {
        public int Id { get; set; }

        public int? CodeVin { get; set; }
       
        public string PhotoUrl { get; set; } = string.Empty;
       
        public string Marque { get; set; } = string.Empty;

        public string Modele { get; set; } = string.Empty;
        public decimal PrixAchat { get; set; }
        public string Finition { get; set; } = string.Empty;

        public int Annee { get; set; }

        public decimal PrixVente { get; set; }
    }
}
