namespace RustyReon.Core;

public class Error
{
    private readonly string _message;
    private readonly Exception? _exception;

    public Error(string message, Exception? exception = null)
    {
        _message = message;
        _exception = exception;
    }
    
    public override string ToString() => _message;
}