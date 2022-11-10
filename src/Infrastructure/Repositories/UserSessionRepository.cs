using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;

public class UserSessionRepository : IUserSessionRepository
{
    private readonly HotellierContext _ctx;

    public UserSessionRepository(HotellierContext ctx)
    {
        _ctx = ctx;
    }

    public Task<UserSession> Load(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Save(UserSession userSession, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}