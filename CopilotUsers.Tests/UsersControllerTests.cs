using System.Net;
using System.Net.Http.Json;
using CopilotUsers.Api.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CopilotUsers.Tests;

public class UsersControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public UsersControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task POST_users_returns_201_and_id()
    {
        var request = new CreateUserRequest
        {
            Name = "Alice",
            Email = "alice@example.com",
            BirthDate = new DateOnly(2000, 1, 1)
        };

        var response = await _client.PostAsJsonAsync("/users", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<CreateUserResponse>();
        Assert.NotNull(body);
        Assert.NotEqual(Guid.Empty, body.Id);
    }
}
