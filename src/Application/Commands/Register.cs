using Application.Services;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands;

public sealed class Register
{
    public record Command
        (Guid UserSessionId, string FirstName, string Surname, string EmailAddress, string Password) : IRequest<Result>;

    public sealed class Handler : IRequestHandler<Command, Result>
    {
        private readonly ICheckEmailUniqueness _checkEmail;
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IUnitOfWork _uow;

        public Handler(IUserSessionRepository userSessionRepository, ICheckEmailUniqueness checkEmail,
            IUnitOfWork uow)
        {
            _userSessionRepository = userSessionRepository;
            _checkEmail = checkEmail;
            _uow = uow;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var emailAddressResult = EmailAddress.Create(request.EmailAddress);
            var firstNameResult = FirstName.Create(request.FirstName);
            var surnameResult = Surname.Create(request.Surname);

            if (emailAddressResult.IsFailure)
                return Result.Failure(emailAddressResult.Error);

            if (firstNameResult.IsFailure || surnameResult.IsFailure)
                return Result.Failure(firstNameResult.IsFailure ? firstNameResult.Error : surnameResult.Error);

            if (await _checkEmail.IsUnique(emailAddressResult.Value))
                return Result.Failure(new Error("Register.AlreadyExists",
                    $"{emailAddressResult.Value} is already in use"));

            var userSession = await _userSessionRepository.Load(request.UserSessionId, cancellationToken);

            if (userSession is null)
                return Result.Failure(new Error("Register.SessionNotFound", "Session could not be found"));

            var registeredUser =
                userSession.Register(firstNameResult.Value, surnameResult.Value, emailAddressResult.Value);

            await _userSessionRepository.Save(registeredUser, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}