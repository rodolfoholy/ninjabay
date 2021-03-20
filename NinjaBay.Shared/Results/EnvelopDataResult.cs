namespace NinjaBay.Shared.Results
{
    public class EnvelopDataResult<T> : EnvelopResult
    {
        public T Data { get; private set; }

        public static EnvelopDataResult<T> Ok(T data)
        {
            return new EnvelopDataResult<T>
            {
                Data = data
            };
        }
    }
}