using System.Collections.Generic;
using FamilySite.Models;

namespace FamilySite.Services.Contracts
{
    public interface IEventService
    {
        TResult GetEvent<TResult>(int id);

        TResult GetEvent<TResult>(string code);

        ICollection<TResult> GetEvents<TResult>();

        int AddEvent(EventModel model);

        void UpdateEvent(EventModel model);

        void DeleteEvent(int id);
    }
}