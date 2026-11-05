using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IMarqueService
    {
        public IEnumerable<Marque> RecupererToutesLesMarques();
    }
}
