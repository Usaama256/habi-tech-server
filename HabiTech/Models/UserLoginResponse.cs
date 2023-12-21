using Habitech.Contracts.User;

namespace HabiTech.Models;

public class UserLoginResponse {
	public  int Id { get; }
	public string Email { get; }
	public string Username { get; }
	public string ProfilePicture { get; }
	
	public UserLoginResponse(int id, string email, string username, string profilePicture)
	{
		Id = id;
		Email = email;
		Username = username;
		ProfilePicture = profilePicture;
	}
}