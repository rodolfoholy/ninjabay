namespace SenacSp.ProjetoIntegrador.Shared.Results
{
    public class EnvelopDataResult<T> : EnvelopResult
    {
        public T Data { get; private set; }

        public static EnvelopDataResult<T> Ok(T data) => new EnvelopDataResult<T>
        {
            Data = data
        };
    }
}