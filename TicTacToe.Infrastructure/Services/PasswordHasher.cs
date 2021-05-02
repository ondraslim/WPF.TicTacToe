using System;
using System.Linq;
using System.Security.Cryptography;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int PBKDF2IterCount = 100_000;
        private const int PBKDF2SubkeyLength = 160 / 8;
        private const int SaltSize = 128 / 8;

        public (string, string) GetPassAndSalt(string passwordHash)
        {
            var result = passwordHash.Split(',');
            return result.Length != 2 ? (string.Empty, string.Empty) : (result[0], result[1]);
        }

        public bool VerifyHashedPassword(string hashedPassword, string salt, string password)
        {
            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            var saltBytes = Convert.FromBase64String(salt);

            using var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, PBKDF2IterCount);
            var generatedSubKey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            return hashedPasswordBytes.SequenceEqual(generatedSubKey);
        }

        public Tuple<string, string> CreateHash(string password)
        {
            using var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount);
            var salt = deriveBytes.Salt;
            var subKey = deriveBytes.GetBytes(PBKDF2SubkeyLength);

            return Tuple.Create(Convert.ToBase64String(subKey), Convert.ToBase64String(salt));
        }
    }
}