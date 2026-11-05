using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IFinitionService
    {
        public IEnumerable<Finition> RecupererFinitionsSelonModele(int modeleId);
        public IEnumerable<Finition> RecupererToutesLesFinitions();
    }
}
