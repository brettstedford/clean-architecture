using Domain.ValueObjects;

namespace Application.Services;

public interface ICheckEmailUniqueness
{
    Task<bool> IsUnique(EmailAddress emailAddress);
}