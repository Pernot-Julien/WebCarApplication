using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IModeleFinitionRepository
    {
        ModeleFinition RecupererModeleFinitionSelonId(int id);
    }
}
