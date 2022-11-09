using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class Password : ValueObject
{
    private static Regex Valid =
        new("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$");


    public string Value { get; }

    private Password(string value)
    {
        Value = value;
    }

    public static Result<Password> Create(string value)
    {
        if (Valid.IsMatch(value))
            return new Password(value);

        return Result.Failure<Password>(new Error("Password.Invalid",
            "Password must be at least 8 characters long and contain at least 2 uppercase characters, 3 lowercase characters, 2 digits and a special character"));
    }
    
    public string GetHash() 

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}