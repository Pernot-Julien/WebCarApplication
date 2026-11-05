using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IModeleService
    {
        public IEnumerable<Modele> RecupererModeleSelonMarque(int marqueId);
        public IEnumerable<Modele> RecupererTousLesModeles();
    }
}
