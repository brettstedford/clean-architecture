
namespace Domain.Shared;

public class Result
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; private set; }
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException();

        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue? value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new Result(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    protected static Result<TValue> Create<TValue>(TValue? value) => Success(value);
}