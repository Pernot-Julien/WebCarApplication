using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IVoitureRepository
    {
     IEnumerable<Voiture> ObtenirToutesLesVoitures();
     Voiture? RechercherVoitureParId(int id);
     void AjouterVoiture(Voiture voiture);
     void ModifierVoiture(Voiture voiture);
     Voiture? SupprimerVoiture(int id);

    }
}
