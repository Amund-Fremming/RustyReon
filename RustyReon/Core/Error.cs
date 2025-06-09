namespace RustyReon.Core;

public class Error
{
    private readonly Exception? _exception;
    public string Message { get; }

    public Error(string message, Exception? exception = null)
    {
        Message = message;
        _exception = exception;
    }
    

    public override string ToString() => Message;
}