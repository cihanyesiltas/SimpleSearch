namespace SimpleSearch.Api.Infrastructure.Exception
{
    public class GlobalResult<T>
    {
        public GlobalResult(T result)
        {
            Result = result;
        }
        public T Result { get; set; }
    }
}