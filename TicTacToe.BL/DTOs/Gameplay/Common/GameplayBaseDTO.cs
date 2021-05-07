using System.ComponentModel;
using System.Runtime.CompilerServices;
using TicTacToe.BL.Annotations;

namespace TicTacToe.BL.DTOs.Gameplay.Common
{
    public class GameplayBaseDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}