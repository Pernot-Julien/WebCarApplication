using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IModeleRepository
    {
        public Modele? RecupererModeleSelonId(int modeleId);
        public IEnumerable<Modele> RecupererTousLesModeles();
    }
}
