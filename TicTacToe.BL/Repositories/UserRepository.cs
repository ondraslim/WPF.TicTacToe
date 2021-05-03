using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.Repositories.Interfaces;
using TicTacToe.Data.Models;
using TicTacToe.Infrastructure.EntityFramework;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.BL.Repositories
{
    public class UserRepository : EntityFrameworkRepository<User, Guid>, IUserRepository
    {
        public UserRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }


        public Task<User> GetUserByNameAsync(string name)
        {
            return Context.Set<User>().FirstOrDefaultAsync(u => u.Name == name);
        }

        public Task<List<User>> GetAllAsync()
        {
            return Context.Set<User>().ToListAsync();
        }
    }
}