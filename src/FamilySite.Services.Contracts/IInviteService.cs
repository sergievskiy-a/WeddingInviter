using FamilySite.Models;

namespace FamilySite.Services.Contracts
{
    public interface IInviteService
    {
        TResult GetInvite<TResult>(int id);

        TResult GetInvite<TResult>(string alias);

        int AddInvite(InviteModel model);

        void UpdateInvite(InviteModel model);

        void CreateInviteAnswer(InviteAnswerModel model);

        void DeleteInvite(int id);
    }
}
