namespace BuberDinner.Cotracts.Authentication;

public record LoginRequest(
    string Email,
    string Password);