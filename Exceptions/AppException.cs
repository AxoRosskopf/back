namespace Exceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; }
        public object? Details { get; }

        public AppException(string message, int status = 500, object? details = null) : base(message)
        {
            StatusCode = status;
            Details = details;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Status: {StatusCode}, Details: {Details}";
        }
    }
}