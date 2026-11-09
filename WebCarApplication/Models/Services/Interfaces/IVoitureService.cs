using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IVoitureService
    {
        public decimal CalculerPrixVente(Voiture voiture, IEnumerable<Reparation> reparations);
        public Voiture AjouterVoiture(Voiture voiture);
        public void ModifierVoiture(Voiture voiture);
        public Voiture? RechercherVoitureParId(int id);
    }
}
