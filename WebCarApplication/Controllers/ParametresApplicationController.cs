using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCarApplication.Models.Services.Interfaces;
using WebCarApplication.Models.ViewModels;

namespace WebCarApplication.Controllers
{
    [Authorize]
    public class ParametresController : Controller
    {
        private readonly IParametresApplicationService _parametresApplicationService;

        public ParametresController(
            IParametresApplicationService parametresApplicationService)
        {
            _parametresApplicationService = parametresApplicationService;
        }

        public IActionResult Index()
        {
            var parametres = _parametresApplicationService.RecupererParametres();

            var viewModel = new ParametresApplicationViewModel
            {
                MargeBenefice = parametres.MargeBenefice
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ParametresApplicationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var parametres = _parametresApplicationService.RecupererParametres();
            parametres.MargeBenefice = viewModel.MargeBenefice;

            _parametresApplicationService.ModifierParametres(parametres);

            TempData["Message"] = "La marge bénéficiaire a été mise à jour.";

            return RedirectToAction(nameof(Index));
        }
    }
}
