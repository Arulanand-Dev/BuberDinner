namespace BuberDinner.Cotracts.Authentication;

public record AuthenticationResponse(
    Guid id,
    string firstName,
    string lastName,
    string email,
    string token);