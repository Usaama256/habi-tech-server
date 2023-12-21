namespace HabiTech.Models;

public class Light 
{
	public int User_id { get; set; }
	public int Device_id { get; set; }
	public string? Device_name { get; set; }
	public string? Device_description { get; set; }
	public string? Type_name { get; set; }
	public string? Status { get; set; }
	
	public Light(int user_id, int device_id, string device_name, string device_description, string type_name, string status)
	{
		User_id = user_id;
		Device_id = device_id;
		Device_name = device_name;
		Device_description = device_description;
		Type_name = type_name;
		Status = status;
	}
	
	public Light()
	{
		
	}
}