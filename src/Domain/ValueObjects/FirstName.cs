using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    private const int MaxLength = 25;

    public string Value { get; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static Result<FirstName> Create(string value)
    {
        if (value.Length > MaxLength)
            return (Result<FirstName>)Result<FirstName>.Failure(new Error("FirstName.ExceededLength",
                $"Surname must be no more than {MaxLength:N} characters"));

        return Result<FirstName>.Success(new FirstName(value));
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}