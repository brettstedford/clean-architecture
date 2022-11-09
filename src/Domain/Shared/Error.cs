namespace Domain.Shared;

public class Error : IEquatable<Error>
{
    public static Error None => new Error(string.Empty, string.Empty);

    public string Code { get; }
    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static implicit operator string(Error error) => error.Code;

    public static bool operator ==(Error? first, Error? second)
    {
        if (first is null && second is null)
            return true;

        if (first is null || second is null)
            return false;

        return first.Code == second.Code;
    }

    public static bool operator !=(Error? first, Error? second) => !(first == second);

    public override bool Equals(object? obj) => obj is Error error && error.Code == Code;

    public override int GetHashCode() => Code.GetHashCode() * 41;

    public bool Equals(Error? other) => other is not null && other.Code == Code;
}
