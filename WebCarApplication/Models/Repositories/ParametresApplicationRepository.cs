using Microsoft.EntityFrameworkCore;
using WebCarApplication.Data;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;
namespace WebCarApplication.Models.Repositories
{
    public class ParametresApplicationRepository : IParametresApplicationRepository
    {
        readonly ApplicationDbContext _context;
        public ParametresApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ParametresApplication RecupererParametres()
        {
            return _context.ParametresApplication.FirstOrDefault() ?? new ParametresApplication();
        }
        public void ModifierParametres(ParametresApplication parametres)
        {
            _context.ParametresApplication.Update(parametres);
            _context.SaveChanges();
        }
    }
}
