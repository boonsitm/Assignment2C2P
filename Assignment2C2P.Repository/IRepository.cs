using System.Collections.Generic;

namespace Assignment2C2P.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity Add(TEntity entity);
    }
}
