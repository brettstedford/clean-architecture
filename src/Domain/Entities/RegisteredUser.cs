using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class RegisteredUser : UserSession
{
    public FirstName FirstName { get; private set; }
    public Surname Surname { get; private set; }
    public EmailAddress EmailAddress { get; private set; }

    private RegisteredUser(Guid id) : base(id)
    {
    }

    public static RegisteredUser Create(FirstName firstname, Surname surname, EmailAddress emailAddress)
    {
        return new RegisteredUser(Guid.NewGuid())
        {
            FirstName = firstname, Surname = surname, EmailAddress = emailAddress
        };
    }
}