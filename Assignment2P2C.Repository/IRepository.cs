using System.Collections.Generic;

namespace Assignment2P2C.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity Get(int internalId);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int internalId);
    }
}
