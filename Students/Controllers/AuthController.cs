using Application.Services;
using Application.Services.Auth.Validators;
using Application.Students.Models;
using Application.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Students.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] string username, [FromQuery] string password, CancellationToken cancellationToken)
        {
            var model = new LoginModel { Username = username, Password = password };
            var validationResult = await new UserLoginValidator().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var result = await _mediator.Send(new LoginCommand { Username = model.Username, HashedPassword = model.Password }, cancellationToken);

                if (result.IsSuccess)
                {
                    return Ok(new { Token = result.Value });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            else
            {
                var validationErrors = validationResult.Errors.Select(error => new { Message = error.ErrorMessage });
                return BadRequest(new { Errors = validationErrors });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model, CancellationToken cancellationToken)
        {
            var validationResult = await new UserRegisterValidator().ValidateAsync(model);

            if (validationResult.IsValid)
            {
                var result = await _mediator.Send(new RegisterCommand { Username = model.Username, Password = model.Password }, cancellationToken);

                if (result.IsSuccess)
                {
                    return Ok(new { Token = result.Value });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            else
            {
                var validationErrors = validationResult.Errors.Select(error => new { Message = error.ErrorMessage });
                return BadRequest(new { Errors = validationErrors });
            }
        }


    }
}
