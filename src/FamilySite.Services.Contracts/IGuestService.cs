using FamilySite.Models;

namespace FamilySite.Services.Contracts
{
    public interface IGuestService
    {
        TResult GetGuest<TResult>(int id);

        int AddGuest(GuestModel model);

        void UpdateGuest(GuestModel model);

        void DeleteGuest(int id);
    }
}
