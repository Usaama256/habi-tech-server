namespace Habitech.Contracts.User;

public record CreateLoginResponse (
    int Id,
    string Email,
    string Username,
    string ProfilePicture
);