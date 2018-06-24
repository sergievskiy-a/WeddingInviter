using System.Collections.Generic;
using FamilySite.Models;

namespace FamilySite.Services.Contracts
{
    public interface IInviteService
    {
        TResult GetInvite<TResult>(int id);

        TResult GetInvite<TResult>(string alias);

        int AddInvite(InviteModel model);

        void UpdateInvite(InviteModel model);

        ICollection<TResult> GetInvitesWithAnswers<TResult>();

        void CreateInviteAnswer(InviteAnswerModel model);

        void UpdateInviteAnswer(InviteAnswerModel model);

        void DeleteInvite(int id);
    }
}
