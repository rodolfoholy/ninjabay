namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class BaseEntity
    {
        public object Clone() => this.MemberwiseClone();

    }
}