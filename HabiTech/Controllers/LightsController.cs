using HabiTech.Models;
using HabiTech.Services.LightServices;
using Microsoft.AspNetCore.Mvc;

namespace HabiTech.Controllers;

[ApiController]

[Route("/habitech.api")]
public class LightsController : ControllerBase
{
	private readonly ILightService _lightservice;
	
	public LightsController(ILightService lightService)
	{
		_lightservice = lightService;
	}
	
	[HttpGet("allLights/{user_id:int}")]
	public IActionResult GetAllLights(int user_id)
	{
		List<Light> lights = _lightservice.GetAllUserLights(user_id);
		
		return Ok(lights);
	}
		
	[HttpGet("switchalllights/{_action:int}/{user_id:int}")]
	public IActionResult SwitchAllUserLights(int _action, int user_id)
	{
		List<Light> lights = _lightservice.SwitchAllUserLights(user_id, _action);
		
		return Ok(lights);
	}
	
	[HttpGet("switchlight/{device_id:int}/{_action:int}/{user_id:int}")]
	public IActionResult SwitchSingleUserLight(int device_id, int _action, int user_id)
	{
		List<Light> lights = _lightservice.SwitchUserLight(user_id, _action, device_id);
		
		return Ok(lights);
	}
	
}