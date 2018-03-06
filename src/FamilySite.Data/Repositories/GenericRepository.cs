using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FamilySite.Data.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FamilySite.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        protected DbSet<TEntity> Entities => this.Context.Set<TEntity>();

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] properties)
        {
            return predicate != null ?
                this.GetQueryWithIncludes(properties).Where(predicate).SingleOrDefault() :
                this.GetQueryWithIncludes(properties).SingleOrDefault();
        }

        public TEntity Find(params object[] param)
        {
            if (!param.Any())
                throw new Exception("Can't find any entities without any parameters specified");

            return this.Entities.Find(param);
        }

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] properties)
        {
            return predicate != null ?
                this.GetQueryWithIncludes(properties).Where(predicate) :
                this.GetQueryWithIncludes(properties);
        }

        public void Add(TEntity entity)
        {
            this.Entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Entities.AddRange(entities);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            this.Entities.RemoveRange(entities);
        }

        public void Delete(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        protected IQueryable<TEntity> GetQueryWithIncludes(params Expression<Func<TEntity, object>>[] properties)
        {
            var query = this.Entities as IQueryable<TEntity>;
            if (properties != null)
            {
                query = properties.Aggregate(query, (current, property) => current.Include(property));
            }
            return query;
        }
    }
}
