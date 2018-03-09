using System.Threading.Tasks;

namespace FamilySite.Web.Api.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
