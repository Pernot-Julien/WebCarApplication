using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IFinitionRepository
    {
       Finition RecupererFinitionSelonId(int finitionId);

       IEnumerable<Finition> RecupererToutesLesFinitions();
     }
}
