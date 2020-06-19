using System.Collections.Generic;

namespace Assignment2P2C.BusinessLogic
{
    public interface IBusinessLogic<Item> where Item : class
    {
        IList<Item> GetAll();
        Item Add(Item item);
    }
}
