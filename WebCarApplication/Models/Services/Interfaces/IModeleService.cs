using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IModeleService
    {
         Modele? RecupererModeleSelonId(int modeleId);
         IEnumerable<Modele> RecupererTousLesModeles();
         IEnumerable<Modele> RecupererModelesSelonMarqueId(int marqueId);
    }
}
