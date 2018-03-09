using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilySite.Data.Contracts.Repositories;
using FamilySite.Data.Entites;
using FamilySite.Models;
using FamilySite.Services.Contracts;

namespace FamilySite.Services
{
    public class EventService : IEventService
    {
        private readonly IWeddingService weddingService;
        private readonly IGenericRepository<Event> eventRepository;
        private readonly IMapper mapper;

        public EventService(
            IWeddingService weddingService,
            IGenericRepository<Event> eventRepository,
            IMapper mapper)
        {
            this.weddingService = weddingService;
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        public TResult GetEvent<TResult>(int id)
        {
            var result = this.eventRepository
                .GetMany(x => x.Id == id)
                .ProjectTo<TResult>(this.mapper.ConfigurationProvider).FirstOrDefault();

            if (result == null) throw new Exception("Not found");

            return result;
        }

        public TResult GetEvent<TResult>(string code)
        {
            var invite = this.eventRepository
                .GetMany(x => x.Code.ToLower() == code.ToLower())
                .ProjectTo<TResult>(this.mapper.ConfigurationProvider).FirstOrDefault();

            if (invite == null) throw new Exception("Not found");

            return invite;
        }

        public ICollection<TResult> GetEvents<TResult>()
        {
            var weddingId = this.weddingService.GetWeddingId();

            var result = this.eventRepository
                .GetMany(x => x.WeddingId == weddingId)
                .ProjectTo<TResult>(this.mapper.ConfigurationProvider)
                .ToList();

            if (result == null) throw new Exception("Not found");

            return result;
        }

        public int AddEvent(EventModel model)
        {
            var eventEntity = this.mapper.Map<Event>(model);

            eventEntity.WeddingId = this.weddingService.GetWeddingId();

            if (this.eventRepository.GetMany(x => x.Code.ToLower() == model.Code.ToLower()).Any())
                throw new Exception("The invite with this alias already existed");

            this.eventRepository.Add(eventEntity);
            this.eventRepository.Save();

            return eventEntity.Id;
        }

        public void UpdateEvent(EventModel model)
        {
            var eventEntity = this.eventRepository.GetSingle(
                x => x.Id == model.Id,
                include => include.Location);
            if (eventEntity == null) throw new Exception("Not found");

            this.mapper.Map(model, eventEntity);

            this.eventRepository.Save();
        }

        public void DeleteEvent(int id)
        {
            var eventEntity = this.eventRepository.GetSingle(x => x.Id == id);
            if (eventEntity == null) throw new Exception("Not found");

            this.eventRepository.Delete(eventEntity);
            this.eventRepository.Save();
        }
    }
}
