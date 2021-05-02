using System;

namespace TicTacToe.BL.Exceptions
{
    public class UserAuthException : Exception
    {
        public UserAuthException()
        {
        }

        public UserAuthException(string message) : base(message)
        {
        }

        public UserAuthException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}