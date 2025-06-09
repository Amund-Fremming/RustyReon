using RustyReon.Exceptions;

namespace RustyReon.Core;

public enum Option 
{
    None
}

public class Option<T>
{
    private readonly T? _data;
    private readonly Option? _option;

    private Option(T? data = default, Option? option = null)
    {
        _data = data;
        _option = option;
    }

    public bool None => _option is not null;
    public bool Some => _option is null;
    
    public T Unwrap()
    {
        if (_option is not null)
        {
            throw new EmptyOptionException("Cannot unwrap empty option");
        }
        
        return _data!;
    }

    public static implicit operator Option<T>(T data) => new(data);
    public static implicit operator Option<T>(Option option) => new(default, option);
}