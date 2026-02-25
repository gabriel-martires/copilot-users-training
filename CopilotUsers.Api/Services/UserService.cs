using CopilotUsers.Api.DTOs;
using CopilotUsers.Api.Models;
using CopilotUsers.Api.Repositories;

namespace CopilotUsers.Api.Services;

public interface IUserService
{
    Task<CreateUserResponse> CreateAsync(CreateUserRequest request, CancellationToken ct);
}

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateUserResponse> CreateAsync(CreateUserRequest request, CancellationToken ct)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name.Trim(),
            Email = request.Email.Trim().ToLowerInvariant(),
            BirthDate = request.BirthDate,
            IsActive = true,
            CreatedAtUtc = DateTime.UtcNow
        };

        await _repository.AddAsync(user, ct);

        return new CreateUserResponse { Id = user.Id };
    }
}
