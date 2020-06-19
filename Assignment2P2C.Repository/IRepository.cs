using System.Collections.Generic;

namespace Assignment2P2C.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity Add(TEntity entity);
    }
}
