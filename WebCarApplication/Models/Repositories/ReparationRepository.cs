using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using WebCarApplication.Data;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Models.Services.Interfaces;

namespace WebCarApplication.Models.Repositories
{
    public class ReparationRepository: IReparationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReparationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Reparation EnregistrerReparation(Reparation reparation)
        {
            _context.Reparations.Add(reparation);
            _context.SaveChanges();

            return reparation;
        }
        public Reparation? RecupererReparationSelonIdVoiture(int voitureId)
        {
            return _context.Reparations.FirstOrDefault(r => r.VoitureId == voitureId);
        }
    }
}
