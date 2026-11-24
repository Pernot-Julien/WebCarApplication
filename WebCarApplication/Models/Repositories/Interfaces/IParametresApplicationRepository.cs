namespace WebCarApplication.Models.Repositories.Interfaces;

using WebCarApplication.Models.Entities;

public interface IParametresApplicationRepository
{
    ParametresApplication RecupererParametres();
    void ModifierParametres(ParametresApplication parametres);
}
