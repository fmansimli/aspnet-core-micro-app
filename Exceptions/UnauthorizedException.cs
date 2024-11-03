namespace AspNet_micro_app.Exceptions;

public class UnauthorizedException : BaseException
{
    public UnauthorizedException(string message) : base(message)
    {
    }

    public override int HttpCode => 401;
}