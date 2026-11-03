using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebCarApplication.Models.ViewModels
{
    public class CreateVoitureViewModel
    {
        [Display(Name = "Code VIN")]
        public string? CodeVin { get; set; } 

        [Required(ErrorMessage = "L'année est obligatoire")]
        public int Annee { get; set; }

        [Required(ErrorMessage = "La date d'achat est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'achat")]
        public DateTime DateAchat { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Le prix d'achat est obligatoire")]
        [Display(Name = "Prix d'achat (€)")]
        public decimal PrixAchat { get; set; }

        [Required(ErrorMessage = "La date de disponibilité est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name = "Date de disponibilité à la vente")]
        public DateTime DateDisponibiliteVente { get; set; }

        [Required(ErrorMessage = "Le prix de vente est obligatoire")]
        [Display(Name = "Prix de vente (€)")]
        public decimal PrixVente { get; set; }

        // Listes déroulantes
        [Required(ErrorMessage = "Veuillez sélectionner une marque")]
        [Display(Name = "Marque")]
        public int MarqueId { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un modèle")]
        [Display(Name = "Modèle")]
        public int ModeleId { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une finition")]
        [Display(Name = "Finition")]
        public int FinitionId { get; set; }

        // Listes pour le formulaire
        public IEnumerable<SelectListItem> MarquesDisponibles { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> ModelesDisponibles { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> FinitionsDisponibles { get; set; } = new List<SelectListItem>();
    }
}
