using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IModeleFinitionService
    {
        ModeleFinition RecupererModeleFinitionSelonId(int id);
    }
}
