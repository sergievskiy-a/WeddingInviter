using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilySite.Data.Contracts.Repositories;
using FamilySite.Data.Entites;
using FamilySite.Models;
using FamilySite.Services.Contracts;

namespace FamilySite.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGenericRepository<Guest> guestRepository;
        private readonly IMapper mapper;

        public GuestService(
            IGenericRepository<Guest> guestRepository,
            IMapper mapper)
        {
            this.guestRepository = guestRepository;
            this.mapper = mapper;
        }

        public TResult GetGuest<TResult>(int id)
        {
            var guest = this.guestRepository
                .GetMany(x => x.Id == id)
                .ProjectTo<TResult>(this.mapper.ConfigurationProvider).FirstOrDefault();

            if (guest == null) throw new Exception("Not found");

            return guest;
        }

        public int AddGuest(GuestModel model)
        {
            var guestEntity = this.mapper.Map<Guest>(model);

            this.guestRepository.Add(guestEntity);
            this.guestRepository.Save();

            return guestEntity.Id;
        }

        public void UpdateGuest(GuestModel model)
        {
            var guestEntity = this.guestRepository.GetSingle(x => x.Id == model.Id);
            if (guestEntity == null) throw new Exception("Not found");

            this.mapper.Map(model, guestEntity);

            this.guestRepository.Save();
        }

        public void DeleteGuest(int id)
        {
            var guestEntity = this.guestRepository.GetSingle(x => x.Id == id);
            if (guestEntity == null) throw new Exception("Not found");

            this.guestRepository.Delete(guestEntity);
            this.guestRepository.Save();
        }
    }
}