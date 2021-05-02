using System;

namespace TicTacToe.Infrastructure.Services.Interfaces
{
    public interface IPasswordHasher
    {
        (string, string) GetPassAndSalt(string passwordHash);
        bool VerifyHashedPassword(string hashedPassword, string salt, string password);
        Tuple<string, string> CreateHash(string password);
    }
}