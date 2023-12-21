namespace HabiTech.Models;

public class CombinedLoginResponse
{
	public UserLoginResponse User { set; get; }
	public List<Light> Lights { set; get; }
	
	public CombinedLoginResponse(UserLoginResponse user, List<Light> lights)
	{
		User = user;
		Lights = lights;
	} 
}