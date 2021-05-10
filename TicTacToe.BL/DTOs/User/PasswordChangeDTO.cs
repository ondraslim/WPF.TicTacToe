using System;

namespace TicTacToe.BL.DTOs.User
{
    public class PasswordChangeDTO
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirmation { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(OldPassword) &&
                   !string.IsNullOrEmpty(NewPassword) &&
                   !string.IsNullOrEmpty(NewPasswordConfirmation);
        }
    }
}