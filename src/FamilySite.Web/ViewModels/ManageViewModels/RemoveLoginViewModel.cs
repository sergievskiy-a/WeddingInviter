using System.ComponentModel.DataAnnotations;

namespace FamilySite.Web.ViewModels.ManageViewModels
{
    namespace WebApplication1.Models.ManageViewModels
    {
        public class RemoveLoginViewModel
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
        }
    }
}
