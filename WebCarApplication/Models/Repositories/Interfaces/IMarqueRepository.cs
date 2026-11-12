using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IMarqueRepository
    {
        IEnumerable<Marque> RecupererToutesLesMarques();
        Marque? RecupererMarqueSelonId(int marqueId);
    }
}
