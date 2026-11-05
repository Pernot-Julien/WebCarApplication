using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IFinitionRepository
    {
        public IEnumerable<Finition> RecupererFinitionsSelonModele(int modeleId);

        public IEnumerable<Finition> RecupererToutesLesFinitions();
     }
}
