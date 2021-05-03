using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TicTacToe.Core.ViewModels.Common
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task OnInitialized() => Task.CompletedTask;
    }

    public abstract class ViewModelBase<TViewModelParameter> : ViewModelBase, IViewModel<TViewModelParameter>
    {
        protected TViewModelParameter ViewModelParameter;

        protected ViewModelBase(TViewModelParameter viewModelParameter)
        {
            ViewModelParameter = viewModelParameter;
        }
    }
}