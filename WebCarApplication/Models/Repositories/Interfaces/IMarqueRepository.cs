using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IMarqueRepository
    {
       public IEnumerable<Marque> RecupererToutesLesMarques();
       public Marque? RecupererMarqueSelonId(int marqueId);
    }
}
