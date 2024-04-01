using Application.Students.Models;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Commands
{
    public class LoginCommand : IRequest<Result<string>>
    {
        public string Username { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty; // Change to accept hashed password
    }
}
