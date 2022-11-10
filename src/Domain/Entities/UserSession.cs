using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class UserSession : Entity
{
    public UserSession(Guid id) : base(id)
    {
    }

    public RegisteredUser Register(FirstName firstName, Surname surname, EmailAddress emailAddress)
    {
        return RegisteredUser.Create(firstName, surname, emailAddress);
    }
}