using Habitech.Contracts.User;
using HabiTech.Models;
using HabiTech.Services.Crypto;
using HabiTech.Services.LightServices;
using HabiTech.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace HabiTech.Controllers;

[ApiController]

[Route("/habitech.api")]
public class UserController : ControllerBase {
	
	private readonly IUserService _userService;
	private readonly ILightService _lightservice;

	public UserController(IUserService userService, ILightService lightService){
		_userService = userService;
		_lightservice = lightService;
	}

	[HttpPost("login")]
	public IActionResult LoginUser(CreateLoginRequest request){

		User user = _userService.LoginUser(request.Email);
		
		if(user.Id == -1)
		{
			// User not found
			Console.WriteLine("User Not Found");
			return 	BadRequest();
		};
		
		bool passIsTrue = new HashSalt().VerifyPassword(request.Pass, user.Pass, user.Salt);
		
		if(!passIsTrue)
		{
			return BadRequest();
		}
		
		UserLoginResponse _user = new UserLoginResponse(user.Id, user.Email ?? "", user.Username ?? "", user.ProfilePicture ?? "");
		
		List<Light> _lights = _lightservice.GetAllUserLights(user.Id);
		
		CombinedLoginResponse response = new CombinedLoginResponse(_user, _lights);
		
		return Ok(response);
	}


}