using Microsoft.AspNetCore.Mvc;
using WebApplicationFundamental.Abstracts;
using DataService.Models;
using WebApplicationFundamental.Services;

namespace WebApplicationFundamental.Controllers;

[Route("api/user")]
[ApiController]
public class UserController(UserService userService) : ControllerBase // Dependency Injection like NestJS
{
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse.Response<string>), StatusCodes.Status200OK)]
    public async Task<IResult> CreateUser([FromBody] CreateUserAccount user)
    {
        try
        {
            await userService.CreateUser(user);
            return BaseResponse.Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BaseResponse.BadRequest(ex.Message);
        }
    }
}