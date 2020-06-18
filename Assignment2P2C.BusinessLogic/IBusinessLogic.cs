using System.Collections.Generic;

namespace Assignment2P2C.BusinessLogic
{
    public interface IBusinessLogic<Item> where Item : class
    {
        IList<Item> GetAll();
        Item Get(long internalId);
        Item Update(Item item);
        Item Add(Item item);
        void Delete(long internalId);
    }
}
