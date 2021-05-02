using System;
using System.Threading.Tasks;
using TicTacToe.Data.Models;

namespace TicTacToe.BL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Guid Create(User entity);
        void Delete(Guid id);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByIdAsync(Guid id, params string[] includes);
        void Update(User entity);
        Task<User> GetUserByNameAsync(string name);
    }
}