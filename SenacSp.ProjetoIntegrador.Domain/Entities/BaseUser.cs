namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class BaseUser : BaseEntity
    {
        public User User { get; protected set; }
    }
}