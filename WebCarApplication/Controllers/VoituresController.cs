using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarApplication.Data;

namespace WebCarApplication.Controllers
{
    public class VoituresController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VoituresController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
