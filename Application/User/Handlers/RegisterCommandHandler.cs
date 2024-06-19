using Application.Services.Auth.Validators;
using Application.Services.Iservices;
using Application.Students.Eroors;

using Application.User.Commands;
using Domain.Entities;
using Domain.Reposotires;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public RegisterCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            // Vérifiez si l'utilisateur existe déjà
            var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return EroorsHandler.HandleGenericError("Nom d'utilisateur déjà utilisé.");
            }

            // Hachez le mot de passe avec BCrypt
            //  string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Créez un nouvel utilisateur dans votre base de données
            var newUser = new UserDTO
            {
                Username = request.Username,
                PasswordHash = request.Password,
             
            };

            // Enregistrez le nouvel utilisateur
            await _userRepository.CreateUserAsync(newUser, cancellationToken);

            // Générez un token pour le nouvel utilisateur
            var token = _tokenService.GenerateToken(newUser);

            return Result.Ok(token);
        }
    }
}
