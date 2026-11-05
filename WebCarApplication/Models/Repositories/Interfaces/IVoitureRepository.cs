using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IVoitureRepository
    {
        public IEnumerable<Voiture> ObtenirToutesLesVoitures();
        public Voiture? ObtenirVoitureParId(int id);   
        public void AjouterVoiture(Voiture voiture);
        public void ModifierVoiture(Voiture voiture);
        public void SupprimerVoiture(int id);
        public IEnumerable<Photo> RecupererPhotosSelonVoiture(int voitureId);
    }
}
