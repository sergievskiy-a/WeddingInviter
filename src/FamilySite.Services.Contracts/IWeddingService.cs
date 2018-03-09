using FamilySite.Models;

namespace FamilySite.Services.Contracts
{
    public interface IWeddingService
    {
        TResult CreateOrUpdate<TResult>(WeddingModel model);

        TResult GetWedding<TResult>();

        int GetWeddingId();
    }
}