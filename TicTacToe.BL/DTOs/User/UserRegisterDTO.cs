namespace TicTacToe.BL.DTOs.User
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(PasswordConfirmation);
        }
    }
}