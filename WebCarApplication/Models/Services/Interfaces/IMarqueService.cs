using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IMarqueService
    {
         IEnumerable<Marque> RecupererToutesLesMarques();
         Marque? RecupererMarqueSelonId(int marqueId);
    }
}
