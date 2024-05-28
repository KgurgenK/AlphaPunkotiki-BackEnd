using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using AlphaPunkotiki.WebApi.Controllers.Models.AccountsController;
using Microsoft.AspNetCore.Mvc;

namespace AlphaPunkotiki.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountsService accountsService) : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var result = await accountsService.LoginAsync(request.Login, request.Password);

        return result.TryGetFault(out var fault, out var authUserInfo)
            ? fault.ThrowResultError()
            : Ok(new LoginResponse(authUserInfo.User, authUserInfo.JwtToken));
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await accountsService.RegisterAsync(request.AccountCredentials, request.UserInfo);

        return result.TryGetFault(out var fault)
            ? fault.ThrowResultError()
            : Created();
    }
}
