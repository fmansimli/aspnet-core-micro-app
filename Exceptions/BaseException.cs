namespace AspNet_micro_app.Exceptions;

public abstract class BaseException : Exception
{
    public abstract int HttpCode { get; }

    protected BaseException(string message) : base(message)
    {
    }

    public virtual object Serialize()
    {
        return new
        {
            message = Message,
            httpCode = HttpCode
        };
    }
}