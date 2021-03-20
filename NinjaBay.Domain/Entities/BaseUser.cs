namespace NinjaBay.Domain.Entities
{
    public class BaseUser : BaseEntity
    {
        public User User { get; protected set; }
    }
}