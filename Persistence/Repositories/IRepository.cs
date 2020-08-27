using Library.API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Persistence.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Delete(string id);
        void Delete(TEntity entityToDelete);
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void UpdateRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> GetAllAsQueryable();
    }
}