using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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
        return Task.FromResult(_ctx.Sessions.AsNoTracking().SingleOrDefault(s => s.Id == id));
    }

    public async Task Save(UserSession userSession, CancellationToken cancellationToken)
    {
        var exists = _ctx.Sessions.Any(s => s.Id == userSession.Id);

        if (!exists)
        {
            _ctx.Sessions.Add(userSession);
            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}