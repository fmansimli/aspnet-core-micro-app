namespace AspNet_micro_app.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string message) : base(message)
    {
    }

    public override int HttpCode => 400;
}