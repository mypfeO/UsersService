using Application.Services.Iservices;
using Application.Students.Eroors;
using Domain.Reposotires;
using FluentResults;
using BCrypt.Net;
using System.Threading.Tasks;

namespace Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<Result<string>> AuthenticateAsync(string username, string hashedPassword)
        {
            // Retrieve the user from the database based on the provided username
            var user = await _userRepository.GetUserByUsernameAsync(username);

            // Check if the user exists
            if (user == null)
            {
                // Return an error message if the user doesn't exist
                return EroorsHandler.HandleGenericError("Nom d'utilisateur.");
            }

            // Compare the received hashed password with the hashed password stored in the database
            if (!VerifyPassword(hashedPassword, user.PasswordHash))
            {
                // Return an error message if the password doesn't match
                return EroorsHandler.HandleGenericError("Mot de passe incorrect.");
            }

            // Generate a JWT token for the user
            var token = _tokenService.GenerateToken(user);

            // Return the token
            return Result.Ok(token);
        }

        private bool VerifyPassword(string hashedPasswordFromClient, string hashedPasswordFromDatabase)
        {
            return hashedPasswordFromClient== hashedPasswordFromDatabase;
        }
    }
}
