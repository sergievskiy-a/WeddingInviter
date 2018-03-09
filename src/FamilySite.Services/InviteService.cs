﻿using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilySite.Data.Contracts.Repositories;
using FamilySite.Data.Entites;
using FamilySite.Models;
using FamilySite.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FamilySite.Services
{
    public class InviteService : IInviteService
    {
        private readonly IWeddingService weddingService;
        private readonly IGenericRepository<Invite> inviteRepository;
        private readonly IMapper mapper;

        public InviteService(
            IWeddingService weddingService,
            IGenericRepository<Invite> inviteRepository,
            IMapper mapper)
        {
            this.weddingService = weddingService;
            this.inviteRepository = inviteRepository;
            this.mapper = mapper;
        }

        public TResult GetInvite<TResult>(int id)
        {
            var invite = this.inviteRepository
                .GetMany(x => x.Id == id)
                .AsNoTracking()
                .ProjectTo<TResult>(this.mapper.ConfigurationProvider).FirstOrDefault();

            if (invite == null) throw new Exception("Not found");

            return invite;
        }

        public TResult GetInvite<TResult>(string alias)
        {
            var invite = this.inviteRepository
                .GetMany(x => x.Alias.ToLower() == alias.ToLower())
                .AsNoTracking()
                .ProjectTo<TResult>(this.mapper.ConfigurationProvider).FirstOrDefault();

            if (invite == null) throw new Exception("Not found");

            return invite;
        }

        public int AddInvite(InviteModel model)
        {
            var inviteEntity = this.mapper.Map<Invite>(model);

            inviteEntity.WeddingId = this.weddingService.GetWeddingId();

            if (this.inviteRepository.GetMany(x => x.Alias.ToLower() == model.Alias.ToLower()).Any())
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

        public void DeleteInvite(int id)
        {
            var inviteEntity = this.inviteRepository.GetSingle(x => x.Id == id);
            if (inviteEntity == null) throw new Exception("Not found");

            this.inviteRepository.Delete(inviteEntity);
            this.inviteRepository.Save();
        }
    }
}
