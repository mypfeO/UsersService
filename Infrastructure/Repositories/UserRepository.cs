using Domain.Entities;
using Domain.Reposotires;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserDTO> _usersCollection;

        public UserRepository(IMongoDatabase database)
        {
            _usersCollection = database.GetCollection<UserDTO>("users");
        }

        public async Task<Result> CreateUserAsync(UserDTO userDTO, CancellationToken cancellationToken)
        {
           await _usersCollection.InsertOneAsync(userDTO,null,cancellationToken);
            return Result.Ok();
        }

        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            return await _usersCollection.Find(u => u.Username == username).FirstOrDefaultAsync();
        }

       
    }
}
