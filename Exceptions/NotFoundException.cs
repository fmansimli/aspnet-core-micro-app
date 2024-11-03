namespace AspNet_micro_app.Exceptions;

public class NotFoundException : BaseException
{
    public override int HttpCode => 404;

    public NotFoundException(string message) : base(message)
    {
    }
}