using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class EmailAddress : ValueObject
{
    public string Value { get; }

    private EmailAddress(string value)
    {
        Value = value;
    }

    public static Result<EmailAddress> Create(string value)
    {
        // validation?

        return Result<EmailAddress>.Success(new EmailAddress(value));
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}