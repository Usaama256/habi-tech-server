using HabiTech.Database;
using HabiTech.Models;

namespace HabiTech.Services.LightServices;

public class LightService : ILightService
{
	public List<Light> GetAllUserLights(int user_id)
	{
		return new DBConnection().DbGetAllUserLights(user_id);
	}

	public List<Light> SwitchAllUserLights(int user_id, int action)
	{
		return new DBConnection().DbSwitchAllUserLights(user_id, action);
	}

	public List<Light> SwitchUserLight(int user_id, int action, int device_id)
	{
		return new DBConnection().DbSwitchSingleUserLight(user_id, action, device_id);
	}
}