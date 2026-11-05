using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories;
namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IVoitureService
    {
        public decimal CalculerPrixVente(Voiture voiture, IEnumerable<Reparation> reparations);
        public Voiture AjouterVoiture(Voiture voiture);
        public IEnumerable<Photo> RecupererPhotosSelonVoiture(int voitureId);
    }
}
