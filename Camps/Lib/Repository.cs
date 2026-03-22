using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Camps.Lib
{
    public class Repository
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;

            // WinForms-friendly iestatījumi
            _dbContext.Configuration.ProxyCreationEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
        }

        // ----------------------
        // READ-ONLY / Queries
        // ----------------------
        public List<TEntity> GetEntities<TEntity>(bool noTracking = true) where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            if (noTracking) query = query.AsNoTracking();
            return query.ToList();
        }

        public TEntity GetEntityByFilter<TEntity>(Expression<Func<TEntity, bool>> filter, bool noTracking = true) where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            if (noTracking) query = query.AsNoTracking();
            return query.FirstOrDefault(filter);
        }

        public List<TEntity> GetEntitiesByFilter<TEntity>(Expression<Func<TEntity, bool>> filter, bool noTracking = true) where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            if (noTracking) query = query.AsNoTracking();
            return query.Where(filter).ToList();
        }

        // ----------------------
        // CREATE / INSERT
        // ----------------------
        public TEntity InsertEntity<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        // ----------------------
        // UPDATE
        // ----------------------
        public bool UpdateEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entity);
            }

            entry.State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        // ----------------------
        // DELETE
        // ----------------------
        public bool DeleteEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entity);
            }

            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteEntityById<TEntity>(object id) where TEntity : class
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            if (entity == null) return false;

            return DeleteEntity(entity);
        }

        // ----------------------
        // GET BY ID
        // ----------------------
        public TEntity GetEntityById<TEntity>(object id, bool noTracking = true) where TEntity : class
        {
            if (noTracking)
            {
                return _dbContext.Set<TEntity>()
                                 .AsNoTracking()
                                 .FirstOrDefault(e => _dbContext.Set<TEntity>().Create().GetType().GetProperty("Id").GetValue(e).Equals(id));
            }
            else
            {
                return _dbContext.Set<TEntity>().Find(id);
            }
        }

        // ----------------------
        // DATABASE CHECK
        // ----------------------
        public bool DatabaseConnectionCheck()
        {
            try
            {
                return _dbContext.Database.Exists();
            }
            catch
            {
                return false;
            }
        }
    }
}
