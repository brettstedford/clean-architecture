using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class Surname : ValueObject
{
    private const int MaxLength = 25;
    public string Value { get; }

    private Surname(string value)
    {
        Value = value;
    }

    public static Result<Surname> Create(string value)
    {
        if (value.Length > MaxLength)
            return (Result<Surname>)Result<FirstName>.Failure(new Error("Surname.ExceededLength",
                $"Surname must be no more than {MaxLength:N} characters"));

        return Result<Surname>.Success(new Surname(value));
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}