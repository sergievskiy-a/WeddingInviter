using System;
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
    public class WeddingService : IWeddingService
    {
        private readonly IGenericRepository<Wedding> weddingRepository;
        private readonly IMapper mapper;

        public WeddingService(
            IGenericRepository<Wedding> weddingRepository,
            IMapper mapper)
        {
            this.weddingRepository = weddingRepository;
            this.mapper = mapper;
        }

        public int GetWeddingId()
        {
            return weddingRepository.GetMany().Any()
                ? weddingRepository
                    .GetMany()
                    .AsNoTracking()
                    .Select(x => x.Id)
                    .FirstOrDefault()
                : this.Create(new WeddingModel()).Id;
        }

        public TResult GetWedding<TResult>()
        {
            var wedding = weddingRepository
                .GetMany()
                .AsNoTracking()
                .ProjectTo<TResult>()
                .FirstOrDefault();

            return wedding == null
                ? this.mapper.Map<TResult>(Create(new WeddingModel()))
                : wedding;
        }

        public TResult CreateOrUpdate<TResult>(WeddingModel model)
        {
            return weddingRepository.GetMany().Any()
                ? Update<TResult>(model)
                : this.mapper.Map<TResult>(Create(model));
        }

        private Wedding Create(WeddingModel model)
        {
            var wedding = this.mapper.Map<Wedding>(model);
            this.weddingRepository.Add(wedding);
            this.weddingRepository.Save();

            return wedding;
        }

        private TResult Update<TResult>(WeddingModel model)
        {
            var weddingEntity = this.weddingRepository.GetSingle();
            if (weddingEntity == null) throw new Exception("Not found");

            this.mapper.Map(model, weddingEntity);
            this.weddingRepository.Save();

            return GetWedding<TResult>();
        }
    }
}
