using IndiaTalks.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
        private readonly UserManager<IdentityUser> userManager;

        //User Manager class create a constructor

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }



        //Create Register Method
        //POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]

        //Create A request DTO for username and Password go to dto folder 
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult= await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                //add roles to this user 
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityUser = await userManager.AddToRolesAsync(user : identityUser.Id , roles: registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login");
                    }
                }
            }
            return BadRequest("something went wrong");


        }
    }
}
