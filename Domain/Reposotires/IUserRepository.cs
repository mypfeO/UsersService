using Domain.Entities;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reposotires
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUserByUsernameAsync(string username);
       Task<Result> CreateUserAsync(UserDTO userDTO, CancellationToken cancellationToken);
    }
}
