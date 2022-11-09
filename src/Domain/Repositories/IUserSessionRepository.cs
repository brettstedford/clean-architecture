using Domain.Entities;

namespace Domain.Repositories;

public interface IUserSessionRepository
{
    Task<UserSession> Load(Guid id, CancellationToken cancellationToken);
    Task Save(UserSession userSession, CancellationToken cancellationToken);
}