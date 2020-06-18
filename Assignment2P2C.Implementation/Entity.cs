using Assignment2P2C.Domain;

namespace Assignment2P2C.Implementation
{
    public abstract class Entity : IEntity
    {
        public virtual int InternalId { get; set; }
    }
}
