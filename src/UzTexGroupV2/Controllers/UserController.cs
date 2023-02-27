using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Route("/{langCode}/api/User")]
[ApiController]
public class UserController : LocalizedControllerBase
{
    private readonly UserService userService;
    public UserController(LocalizedUnitOfWork localizedUnitOfWork, UserService userService) : base(localizedUnitOfWork)
    {
        this.userService = userService;
    }

    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    public async ValueTask<ActionResult<UserDto>> PostUserAsync(
        [FromBody] CreateUserDto createUserDto)
    {
        var createdUser = await this.userService
            .CreateUserAsync(createUserDto);

        return Created("", createdUser);
    }

    [Authorize(Roles = "SuperAdmin")]
    [HttpGet]
    public async ValueTask<ActionResult<UserDto>> GetAllUsers(
        [FromQuery] QueryParameter queryParameter)
    {
        var users = await this.userService
            .RetrieveAllUsersAsync(queryParameter);

        return Ok(users);
    }

    [Authorize]
    [HttpGet("{id:guid}")]
    public async ValueTask<ActionResult<UserDto>> GetUserByIdAsync(
        Guid userId)
    {
        var user = await this.userService
            .RetrieveByIdUserAsync(userId);

        return Ok(user);
    }

    [Authorize(Roles = "SuperAdmin")]
    [HttpPut]
    public async ValueTask<ActionResult<UserDto>> PutUserAsync(
        [FromBody] ModifyUserDto modifyUserDto)
    {
        var modifiedUser = await this.userService
            .ModifyUserAsync(modifyUserDto);

        return Ok(modifiedUser);
    }

    [Authorize(Roles = "SuperAdmin")]
    [HttpDelete("{userId:guid}")]
    public async ValueTask<ActionResult<UserDto>> DeleteUserAsync(
        Guid userId)
    {
        var removed = await this.userService
            .DeleteUserAsync(userId);

        return Ok(removed);
    }
}
