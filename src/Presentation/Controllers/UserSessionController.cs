using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UserSessionController : ControllerBase
{
    private readonly IUserSessionRepository _repo;

    public UserSessionController(IUserSessionRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(Name = "Get")]
    public async Task<IActionResult> Get([FromQuery]Guid id, CancellationToken cancellationToken)
    {
        var session = await _repo.Load(id, cancellationToken);
        return Ok(session);
    }

    [HttpPut(Name = "Create")]
    public async Task<IActionResult> Create([FromBody]Guid id, CancellationToken cancellationToken)
    {
        var newSession = new UserSession(id);
        await _repo.Save(newSession, cancellationToken);
        return Ok(newSession);
    }
}