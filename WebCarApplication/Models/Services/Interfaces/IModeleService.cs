using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IModeleService
    {
        public Modele? RecupererModeleSelonId(int modeleId);
        public IEnumerable<Modele> RecupererTousLesModeles();
    }
}
