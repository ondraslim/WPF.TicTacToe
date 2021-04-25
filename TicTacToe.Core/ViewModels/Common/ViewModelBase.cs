﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToe.Core.ViewModels.Common
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnInitialized() { }
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