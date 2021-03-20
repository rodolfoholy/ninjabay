namespace NinjaBay.Domain.Entities
{
    public class BaseEntity
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}