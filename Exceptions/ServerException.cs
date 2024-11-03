namespace AspNet_micro_app.Exceptions;

public class ServerException : BaseException
{
    public ServerException(string message) : base(message)
    {
    }

    public override int HttpCode => 500;
}