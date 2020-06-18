namespace Assignment2P2C.Domain.Implementation
{
    public abstract class Entity : IEntity
    {
        public virtual int InternalId { get; set; }
    }
}
