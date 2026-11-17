using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Services.Interfaces

{
    public interface IParametresApplicationService
    {
        ParametresApplication RecupererParametres();
        void ModifierParametres(ParametresApplication parametres);
    }
}
