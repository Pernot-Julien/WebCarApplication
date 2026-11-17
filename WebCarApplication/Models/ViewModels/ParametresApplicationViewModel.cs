using System.ComponentModel.DataAnnotations;

namespace WebCarApplication.Models.ViewModels
{
    public class ParametresApplicationViewModel
    {
        [Required(ErrorMessage = "La marge bénéficiaire est obligatoire.")]
        [Range(0, 100000, ErrorMessage = "La marge doit être comprise entre 0 et 100 000 €.")]
        public decimal MargeBenefice { get; set; }
    }
}
