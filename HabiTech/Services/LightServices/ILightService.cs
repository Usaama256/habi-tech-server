using HabiTech.Models;

namespace HabiTech.Services.LightServices;

public interface ILightService 
{
	List<Light> GetAllUserLights(int user_id);
	List<Light> SwitchUserLight(int user_id, int action, int device_id);
	List<Light> SwitchAllUserLights(int user_id, int action);	
}