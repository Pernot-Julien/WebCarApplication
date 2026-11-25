using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IFinitionService
    {
        Finition RecupererFinitionSelonId(int finitionId);
        IEnumerable<Finition> RecupererToutesLesFinitions();
    }
}
