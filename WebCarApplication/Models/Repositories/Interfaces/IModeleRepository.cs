using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IModeleRepository
    {
       Modele? RecupererModeleSelonId(int modeleId);
       IEnumerable<Modele> RecupererTousLesModeles();
    }
}
