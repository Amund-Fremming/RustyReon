using RustyReon.Exceptions;

namespace RustyReon.Core;

public class Result<T> where T : class
{
    private readonly T? _data;
    private readonly Error? _error;

    private Result(T? data = null, Error? error = null)
    {
        _data = data;
        _error = error;
    }

    public T Unwrap()
    {
        if (_error is not null)
        {
            throw new ResultException("Cannot unwrap an empty result");
        }
        
        return _data!;
    }

    public string GetErrorMessage()
    {
        if (_error is null)
        {
            throw new ResultException("Cannot get message from a failed result");
        }

        return _error.Message;
    }

    public static implicit operator Result<T>(T data) => new(data);
    public static implicit operator Result<T>(Error error) => new(null, error);
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
            throw new ResultException("Cannot unwrap an empty result");
        }
        
        return _data!;
    }

    public TError GetError()
    {
        if (_error is not null)
        {
            throw new ResultException("Cannot get error from a successful result");
        }

        return _error!;
    }

    public static implicit operator Result<TData, TError>(TData data) => new(data);
    public static implicit operator Result<TData, TError>(TError error) => new(null, error);
}
