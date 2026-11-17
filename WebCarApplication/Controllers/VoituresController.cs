using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Services;
using WebCarApplication.Models.Services.Interfaces;
using WebCarApplication.Models.ViewModels;

namespace WebCarApplication.Controllers
{
    public class VoituresController : Controller
    {
        private readonly IMarqueService _marqueService;
        private readonly IModeleService _modeleService;
        private readonly IFinitionService _finitionService;
        private readonly IVoitureService _voitureService;
        private readonly IPhotoService _photoService;
        private readonly IReparationService _reparationService;
        private readonly IModeleFinitionService _modeleFinitionService;

        public VoituresController(IVoitureService voitureService, IMarqueService marqueService, IModeleService modeleService, IFinitionService finitionService, IPhotoService photoService, IReparationService reparationService, IModeleFinitionService modeleFinitionService)
        {
            _voitureService = voitureService;
            _marqueService = marqueService;
            _modeleService = modeleService;
            _finitionService = finitionService;
            _photoService = photoService;
            _reparationService = reparationService;
            _modeleFinitionService = modeleFinitionService;     
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var createVoitureViewModel = new CreateVoitureViewModel();
            // ici je veux rechercher toutes les marques 
            createVoitureViewModel.MarquesDisponibles = _marqueService.RecupererToutesLesMarques().Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.NomMarque
            }).ToList();

            createVoitureViewModel.ModelesDisponibles = new List<SelectListItem>();

            createVoitureViewModel.FinitionsDisponibles = new List<SelectListItem>();

            return View(createVoitureViewModel);
        }

        [HttpGet]
        public IActionResult RecupererModelesParMarque(int marqueId)
        {
            var modeles = _modeleService
                .RecupererModelesSelonMarqueId(marqueId);

            var result = modeles.Select(m => new
            {
                id = m.Id,
                nom = m.NomModele
            });

            return Json(result);
        }

        [HttpGet]
        public IActionResult RecupererFinitionsParModele(int modeleId)
        {
            var finitions = _modeleFinitionService
                .RecupererModeleFinitionsSelonModeleId(modeleId);

            var result = finitions.Select(mf => new
            {
                id = mf.Id,
                nom = mf.Finition.NomFinition
            });

            return Json(result);
        }



        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateVoitureViewModel createVoitureViewModel)
        {
            if (!ModelState.IsValid)
            {
                createVoitureViewModel.MarquesDisponibles = _marqueService
                    .RecupererToutesLesMarques()
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomMarque
                    }).ToList();

                return View(createVoitureViewModel);
            }

            var voiture = new Voiture
            {
                CodeVin = createVoitureViewModel.CodeVin,
                Annee = createVoitureViewModel.Annee,
                DateAchat = createVoitureViewModel.DateAchat,
                PrixAchat = createVoitureViewModel.PrixAchat,
                Disponible = createVoitureViewModel.Disponible,
                DateDisponibilite = createVoitureViewModel.DateDisponibilite,
                ModeleFinitionId = createVoitureViewModel.ModeleFinitionId,
                Photos = new List<Photo>()
            };

            if (createVoitureViewModel.Photo != null &&
                createVoitureViewModel.Photo.Length > 0)
            {
                var dossier = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "voitures"
                );

                Directory.CreateDirectory(dossier);

                var extension = Path.GetExtension(createVoitureViewModel.Photo.FileName);
                var fileName = Guid.NewGuid().ToString() + extension;
                var filePath = Path.Combine(dossier, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    createVoitureViewModel.Photo.CopyTo(stream);
                }

                voiture.Photos.Add(new Photo
                {
                    Url = fileName
                });
            }

            _voitureService.AjouterVoiture(voiture);

            var reparation = new Reparation
            {
                DescriptionReparation = createVoitureViewModel.DescriptionReparation,
                CoutReparation = createVoitureViewModel.CoutReparation,
                VoitureId = voiture.Id
            };

            _reparationService.EnregistrerReparation(reparation);

            return RedirectToAction("Create");
        }


        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var voiture = _voitureService.RechercherVoitureParId(id);

            if (voiture == null)
            {
                return NotFound();
            }

            var modeleFinition = _modeleFinitionService.RecupererModeleFinitionSelonId(voiture.ModeleFinitionId);
            var modele = _modeleService.RecupererModeleSelonId(modeleFinition.ModeleId);
            var marque = _marqueService.RecupererMarqueSelonId(modele.MarqueId);
            var photos = _photoService.RecupererPhotosSelonIdVoiture(voiture.Id);

            var updateVoitureViewModel = new UpdateVoitureViewModel
            {
                Id = voiture.Id,
                CodeVin = voiture.CodeVin,
                Annee = voiture.Annee,
                Disponible = voiture.Disponible,

                MarqueId = marque.Id,
                MarquesDisponibles = _marqueService.RecupererToutesLesMarques().Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomMarque
                    }).ToList(),

                ModeleId = modele.Id,
                ModelesDisponibles = _modeleService.RecupererModelesSelonMarqueId(marque.Id).Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomModele
                    }).ToList(),

                ModeleFinitionId = modeleFinition.Id,
                FinitionsDisponibles = _modeleFinitionService .RecupererModeleFinitionsSelonModeleId(modele.Id).Select(mf => new SelectListItem
                {
                    Value = mf.Id.ToString(),
                    Text = mf.Finition.NomFinition
                }).ToList(),

                DateAchat = voiture.DateAchat,
                PrixAchat = voiture.PrixAchat,
                DateDisponibilite = voiture.DateDisponibilite,
                PhotoActuelle = voiture.Photos.FirstOrDefault()?.Url
            };

            return View(updateVoitureViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(UpdateVoitureViewModel updateVoitureViewModel)
        {
            if (!ModelState.IsValid)
            {
                updateVoitureViewModel.MarquesDisponibles = _marqueService
                    .RecupererToutesLesMarques()
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomMarque
                    }).ToList();

                updateVoitureViewModel.ModelesDisponibles = _modeleService
                    .RecupererModelesSelonMarqueId(updateVoitureViewModel.MarqueId)
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomModele
                    }).ToList();

                updateVoitureViewModel.FinitionsDisponibles = _modeleFinitionService
                    .RecupererModeleFinitionsSelonModeleId(updateVoitureViewModel.ModeleId)
                    .Select(mf => new SelectListItem
                    {
                        Value = mf.Id.ToString(),
                        Text = mf.Finition.NomFinition
                    }).ToList();

                return View(updateVoitureViewModel);
            }
            var voiture = _voitureService.RechercherVoitureParId(updateVoitureViewModel.Id);
            if (voiture == null)
            {
                return NotFound();
            }
            voiture.CodeVin = updateVoitureViewModel.CodeVin;
            voiture.Annee = updateVoitureViewModel.Annee;
            voiture.DateAchat = updateVoitureViewModel.DateAchat;
            voiture.PrixAchat = updateVoitureViewModel.PrixAchat;
            voiture.Disponible = updateVoitureViewModel.Disponible;
            voiture.DateDisponibilite = updateVoitureViewModel.DateDisponibilite;
            voiture.ModeleFinitionId = updateVoitureViewModel.ModeleFinitionId;
            if (updateVoitureViewModel.Photo != null)
            {
                var fileName = updateVoitureViewModel.Photo.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "voitures", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    updateVoitureViewModel.Photo.CopyTo(stream);
                }
                voiture.Photos.Clear();
                voiture.Photos.Add(new Photo
                {
                    Url = fileName
                });
            }
            _voitureService.ModifierVoiture(voiture);
            return RedirectToAction("Update", new { id = voiture.Id });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var voiture = _voitureService.SupprimerVoiture(id);
            if (voiture == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
