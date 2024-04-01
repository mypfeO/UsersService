using Application.Students.Models;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Auth.Validators
{
    public class UserLoginValidator : AbstractValidator<LoginModel>
    {
        public UserLoginValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Le nom d'utilisateur est requis.")
           ;

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Le mot de passe est requis.")
               ;
        }
    }
    public class UserRegisterValidator : AbstractValidator<RegisterModel>
    {
        public UserRegisterValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Le nom d'utilisateur est requis.")
                .MinimumLength(3).WithMessage("Le nom d'utilisateur doit avoir au moins 3 caractères.")
                .MaximumLength(50).WithMessage("Le nom d'utilisateur ne peut pas dépasser 50 caractères.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Le mot de passe est requis.")
                .MinimumLength(6).WithMessage("Le mot de passe doit avoir au moins 6 caractères.")
                .MaximumLength(100).WithMessage("Le mot de passe ne peut pas dépasser 100 caractères.");
        }
    }
}
