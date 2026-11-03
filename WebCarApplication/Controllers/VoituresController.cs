using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarApplication.Data;
using WebCarApplication.Models.ViewModels;

namespace WebCarApplication.Controllers
{
    public class VoituresController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VoituresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateVoitureViewModel();

            // (Plus tard, vous remplirez ici vos listes déroulantes de marques/finitions)

            return View(viewModel); // On passe bien le viewModel ici !
        }
    }
}
