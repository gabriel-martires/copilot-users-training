using CopilotUsers.Api.Models;

namespace CopilotUsers.Api.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken ct);
}

public class UserRepository : IUserRepository
{
    public Task AddAsync(User user, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
