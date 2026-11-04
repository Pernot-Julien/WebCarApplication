using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCarApplication.Data;
using WebCarApplication.Models.Services;
using WebCarApplication.Models.Services.Interfaces;
using WebCarApplication.Models.ViewModels;

namespace WebCarApplication.Controllers
{
    public class VoituresController : Controller
    {
        private readonly IVoitureService _voitureService;

        public VoituresController(IVoitureService voitureService)
        {
            _voitureService = voitureService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateVoitureViewModel();

            // Il faudra récupérer les listes en BDD après avoir rentré les données 
            return View(viewModel);

        }


        [HttpPost]
        public IActionResult Create(CreateVoitureViewModel createVoitureViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createVoitureViewModel);
            }
            else
            {
                var voiture = new Models.Entities.Voiture
                {
                    CodeVin = createVoitureViewModel.CodeVin,
                    Annee = createVoitureViewModel.Annee,
                    DateAchat = createVoitureViewModel.DateAchat,
                    PrixAchat = createVoitureViewModel.PrixAchat,
                    DateDisponibilite = createVoitureViewModel.DateDisponibilite,
                    FinitionId = createVoitureViewModel.FinitionId
                };
                _voitureService.AjouterVoiture(voiture);

                return RedirectToAction("Index");

            }
        }
    }
}
