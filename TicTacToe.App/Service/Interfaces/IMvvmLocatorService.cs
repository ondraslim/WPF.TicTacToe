﻿using System.Windows.Controls;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Infrastructure.Services.Common;

namespace TicTacToe.App.Service.Interfaces
{
    public interface IMvvmLocatorService : ISingletonService
    {
        UserControl ResolveView<TViewModel>(TViewModel viewModel = default)
            where TViewModel : class, IViewModel;

        UserControl ResolveView<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;
    }
}