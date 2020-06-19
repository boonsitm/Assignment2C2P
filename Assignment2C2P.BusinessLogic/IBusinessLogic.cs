using System.Collections.Generic;

namespace Assignment2C2P.BusinessLogic
{
    public interface IBusinessLogic<Item> where Item : class
    {
        IList<Item> GetAll();
        Item Add(Item item);
    }
}
