using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IModeleRepository
    {
        IEnumerable<Modele> RecupererModeleSelonMarque(int marqueId);
        public IEnumerable<Modele> RecupererTousLesModeles();
    }
}
