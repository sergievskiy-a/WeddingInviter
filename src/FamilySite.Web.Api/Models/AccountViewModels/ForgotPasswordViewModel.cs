using System.ComponentModel.DataAnnotations;

namespace FamilySite.Web.Api.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
