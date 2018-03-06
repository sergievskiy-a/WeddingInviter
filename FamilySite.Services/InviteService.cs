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
    public class InviteService : IInviteService
    {
        private readonly IGenericRepository<Invite> inviteRepository;
        private readonly IMapper mapper;

        public InviteService(
            IGenericRepository<Invite> inviteRepository,
            IMapper mapper)
        {
            this.inviteRepository = inviteRepository;
            this.mapper = mapper;
        }

        public TResult GetInvite<TResult>(Guid id)
        {
            var invite = this.inviteRepository
                .GetMany(x => x.Id == id)
                .ProjectTo<TResult>(this.mapper.ConfigurationProvider).FirstOrDefault();

            if (invite == null) throw new Exception("Not found");

            return invite;
        }

        public TResult GetInvite<TResult>(string alias)
        {
            var invite = this.inviteRepository
                .GetMany(x => x.Alias.ToLower() == alias.ToLower())
                .ProjectTo<TResult>(this.mapper.ConfigurationProvider).FirstOrDefault();

            if (invite == null) throw new Exception("Not found");

            return invite;
        }

        public Guid AddInvite(InviteModel model)
        {
            var inviteEntity = this.mapper.Map<Invite>(model);

            if (this.inviteRepository.GetMany(x => x.Alias == model.Alias).Any())
                throw new Exception("The invite with this alias already existed");

            this.inviteRepository.Add(inviteEntity);
            this.inviteRepository.Save();

            return inviteEntity.Id;
        }

        public void UpdateInvite(InviteModel model)
        {
            var inviteEntity = this.inviteRepository.GetSingle(x => x.Id == model.Id);
            if (inviteEntity == null) throw new Exception("Not found");

            this.mapper.Map(model, inviteEntity);

            this.inviteRepository.Save();
        }

        public void DeleteWedding(Guid id)
        {
            var inviteEntity = this.inviteRepository.GetSingle(x => x.Id == id);
            if (inviteEntity == null) throw new Exception("Not found");

            this.inviteRepository.Delete(inviteEntity);
            this.inviteRepository.Save();
        }
    }
}
