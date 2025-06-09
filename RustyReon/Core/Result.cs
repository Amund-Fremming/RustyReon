using RustyReon.Exceptions;

namespace RustyReon.Core;

public class Result<T> where T : class
{
    private readonly T? _data;
    private readonly Exception? _exception;
    private readonly string _message;

    private Result(T? data = null, Exception? exception = null, string? message = "")
    {
        _data = data;
        _exception = exception;
        _message = message ?? string.Empty;
    }

    public T Unwrap()
    {
        if (_exception is not null)
        {
            throw new EmptyResultException("Cannot unwrap an empty result");
        }
        
        return _data!;
    }

    public static implicit operator Result<T>(T data) => new(data);
    // implicit operator for return av error
}

public class Result<TData, TError> where TData : class where TError : class 
{
    private readonly TData? _data;
    private readonly TError? _error;

    private Result(TData? data = null, TError? error = null)
    {
        _data = data;
        _error = error;
    }

    public TData Unwrap()
    {
        if (_error is not null)
        {
            throw new EmptyResultException("Cannot unwrap an empty result");
        }
        
        return _data!;
    }

    public static implicit operator Result<TData, TError>(TData data) => new(data);
    public static implicit operator Result<TData, TError>(TError error) => new(null, error);
    // impliic operator av result error
}
