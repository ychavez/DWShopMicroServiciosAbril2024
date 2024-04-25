using Authentication.Api.DTO;
using Authentication.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController(UserManager<DWUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<DWUser> signInManager) : ControllerBase
    {

        private async Task<bool> UserExists(string username)
            => await userManager.Users.AnyAsync(x => x.UserName == username);

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.UserName.ToLower()))
                return BadRequest();

            // estariamos mejor con automapper XD
            var user = new DWUser
            {
                UserName = registerDTO.UserName.ToLower(),
                Email = registerDTO.Email,
                BadgeNumber = registerDTO.Badge,
                Tenant = registerDTO.Tenant
            };

            var result = await userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new UserDTO { UserName = registerDTO.UserName, Token = "" });

        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            if (!await UserExists(loginDTO.UserName.ToLower()))
                return Unauthorized();

            var user = await userManager
                .Users
                .SingleAsync(x => x.UserName == loginDTO.UserName);

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, true);

            if (!result.Succeeded)
                return Unauthorized();

            return Ok(new UserDTO { })

        }

    }
}
