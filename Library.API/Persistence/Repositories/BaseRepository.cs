using Library.API.Context;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ILibraryContext context;
        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(ILibraryContext context)
        {
            this.context = context;
            this.dbSet = context.DbSet<TEntity>();
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> TEntityList)
        {
            dbSet.AddRange(TEntityList);
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Delete(string id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);

            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            entities
                .Select(x =>
                {
                    dbSet.Attach(x);
                    context.Entry(x).State = EntityState.Modified;
                    return x;

                });

            dbSet.UpdateRange(entities);
        }

        public virtual IQueryable<TEntity> GetAllAsQueryable()
        {
            return dbSet.AsQueryable();
        }
    }
}
