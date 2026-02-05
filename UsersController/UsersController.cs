using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Application.DTOs;
using UserManagement.API.Services.Interfaces;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateUserDto dto, CancellationToken ct)
        {
            try
            {
                var created = await _userService.CreateAsync(dto, ct);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex) // email duplicado (por enquanto)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var users = await _userService.GetAllAsync(ct);
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var user = await _userService.GetByIdAsync(id, ct);
            return user is null ? NotFound() : Ok(user);
        }
    }
}
