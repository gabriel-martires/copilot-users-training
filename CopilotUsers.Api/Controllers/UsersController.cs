using CopilotUsers.Api.DTOs;
using CopilotUsers.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CopilotUsers.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request, CancellationToken ct)
    {
        var response = await _userService.CreateAsync(request, ct);
        return Created($"/users/{response.Id}", response);
    }
}
