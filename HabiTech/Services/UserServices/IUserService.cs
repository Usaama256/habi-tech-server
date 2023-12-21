using HabiTech.Models;

namespace HabiTech.Services.UserServices;

public interface IUserService{
    User LoginUser(string email);
    User CreateUser(User user);
    User UpdateUser(User user);
    bool DisactivateUser(User user);
    
}