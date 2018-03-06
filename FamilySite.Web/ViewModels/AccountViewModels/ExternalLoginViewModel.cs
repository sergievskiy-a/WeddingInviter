using System.ComponentModel.DataAnnotations;

namespace FamilySite.Web.ViewModels.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}