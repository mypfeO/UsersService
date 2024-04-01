using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Iservices
{
    public interface IAuthService
    {
        Task<Result<string>> AuthenticateAsync(string username, string password);
    }
}
