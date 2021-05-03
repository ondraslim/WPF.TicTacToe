using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Data.Models;

namespace TicTacToe.BL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> CreateAsync(User entity);
        Task DeleteAsync(Guid id);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByIdAsync(Guid id, params string[] includes);
        Task UpdateAsync(User entity);
        Task<User> GetUserByNameAsync(string name);
        Task<List<User>> GetAllAsync();
    }
}