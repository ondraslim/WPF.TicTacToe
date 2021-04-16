using System.ComponentModel;
using System.Runtime.CompilerServices;
using TicTacToe.App.Annotations;

namespace TicTacToe.App.Views.Gameplay
{
    public class BoardCell : INotifyPropertyChanged
    {
        private string sign;
        private bool canSelect = true;

        public string Sign
        {
            get => sign;
            set
            {
                sign = value;
                if (value != null)
                    CanSelect = false;
                OnPropertyChanged();
            }
        }

        public bool CanSelect
        {
            get => canSelect;
            set
            {
                canSelect = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}