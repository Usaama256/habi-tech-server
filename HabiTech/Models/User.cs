using Microsoft.AspNetCore.RateLimiting;

namespace HabiTech.Models;

public class User {
	public int Id { get; set;}
	public string Username { get; set; }
	public string Email { get; set; }
	public string Pass { set; get; }
	public string ProfilePicture { get; set; }
	public string Salt { get; }


	public User(int id, string userName, string email, string profilePicture, string pass, string salt){
		Id = id;
		Username = userName;
		Email = email;
		Pass = pass;
		ProfilePicture = profilePicture;
		Salt = salt;		
	}
}
