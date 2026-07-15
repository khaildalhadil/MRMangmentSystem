using HRMangment.Application.Dtos.UserDto;
using HRMangment.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMangment.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[AllowAnonymous]
public class AccountController(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    RoleManager<ApplicationRole> roleManager
    ) : Controller
{

    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

    [HttpPost]
    public async Task<ActionResult<ApplicationUser>> Register(RegisterDTO registerDTO)
    {

        //1) check for errors
        if (!ModelState.IsValid)
        {
            string errors =
                string.Join(
                    " | ",
                    ModelState.Values.SelectMany(error => error.Errors).Select((e) => e.ErrorMessage));

            return Problem(errors);
        }

        //check if user alredy in db
       var exists = await _userManager.FindByEmailAsync(registerDTO.Email);

        if (exists != null)
        {
            return BadRequest(new { message = "Email is already Exists" });
        }


        //2) make user object
        ApplicationUser user = new ApplicationUser()
        {

            UserName = registerDTO.UserName,
            PhoneNumber = registerDTO.PhoneNumber,
            Email = registerDTO.Email,
        };

        //3) sore user in db
        IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

        // 4) check if usre stored succee
        if(result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok(user);

        // 5) check if usre not stored succee
        }
        else
        {
            string errors = string.Join(" | ", result.Errors.Select(e => e.Description));
            return BadRequest(errors);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        //1) check for errors
        if (!ModelState.IsValid)
        {
            string errors =
                string.Join(
                    " | ",
                    ModelState.Values.SelectMany(error => error.Errors).Select((e) => e.ErrorMessage));

            return Problem(errors);
        }

        var userFromDb = await _userManager.FindByEmailAsync(loginDto.Email);
        if (userFromDb is null) return Unauthorized();

        var res = await _signInManager.CheckPasswordSignInAsync(userFromDb, loginDto.Password, lockoutOnFailure: false);

        if (res.Succeeded)
        {
            return Ok(userFromDb);
        }
        else
        {
            return Unauthorized("Invalid Email and Password");
        }
    }

    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return NoContent();
    }
}
