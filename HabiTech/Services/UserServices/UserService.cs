using HabiTech.Database;
using HabiTech.Models;

namespace HabiTech.Services.UserServices;

public class UserService : IUserService
{
	
	public User CreateUser(User user)
	{
		throw new NotImplementedException();
	}

	public bool DisactivateUser(User user)
	{
		throw new NotImplementedException();
	}

	public User LoginUser(string email)
	{
	 return new DBConnection().DbDetUser(email);	  
	}

	public User UpdateUser(User user)
	{
		throw new NotImplementedException();
	}
}