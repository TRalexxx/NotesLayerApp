using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesLayerApp.Application.Services.Identity;
using NotesLayerApp.Core.Dto;
using NotesLayerApp.Core.Entities;

namespace NotesLayerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> Register(User user)
        {
            var result = await _identityService.RegisterAsync(user);

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(User user)
        {
            var result = await _identityService.LoginAsync(user);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
