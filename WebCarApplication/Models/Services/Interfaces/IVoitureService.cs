using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IVoitureService
    {
         decimal CalculerPrixVente(Voiture voiture, IEnumerable<Reparation> reparations);
         Voiture AjouterVoiture(Voiture voiture);
         void ModifierVoiture(Voiture voiture);
         Voiture? RechercherVoitureParId(int id);
         Voiture? SupprimerVoiture(int id);
         IEnumerable<Voiture> ObtenirToutesLesVoitures();

    }
}
