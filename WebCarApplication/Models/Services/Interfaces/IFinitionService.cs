using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IFinitionService
    {
        public Finition RecupererFinitionSelonId(int finitionId);
        public IEnumerable<Finition> RecupererToutesLesFinitions();
    }
}
