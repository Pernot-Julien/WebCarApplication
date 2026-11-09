using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IFinitionRepository
    {
        public Finition RecupererFinitionSelonId(int finitionId);

        public IEnumerable<Finition> RecupererToutesLesFinitions();
     }
}
