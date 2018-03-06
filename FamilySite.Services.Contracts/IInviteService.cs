using System;
using FamilySite.Models;

namespace FamilySite.Services.Contracts
{
    public interface IInviteService
    {
        TResult GetInvite<TResult>(Guid id);
        TResult GetInvite<TResult>(string alias);

        Guid AddInvite(InviteModel model);

        void UpdateInvite(InviteModel model);

        void DeleteWedding(Guid id);
    }
}
