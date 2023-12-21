namespace Habitech.Contracts.User;

public record CreateLoginRequest(
    string Email,
    string Pass
);