using System;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.App.Views;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Infrastructure.IoC;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.App.Service
{
    public class MvvmLocatorService : IMvvmLocatorService
    {
        private readonly IDependencyInjectionService dependencyInjectionService;

        public MvvmLocatorService(IDependencyInjectionService dependencyInjectionService)
        {
            this.dependencyInjectionService = dependencyInjectionService;
        }

        public Window ResolveWindow<TViewModel>(TViewModel viewModel = default) where TViewModel : class, IViewModel
        {
            var windowType = GetWindowType(viewModel);
            return GetWindow<TViewModel>(windowType);
        }

        public UserControl ResolveView<TViewModel>(TViewModel viewModel = default)
            where TViewModel : class, IViewModel
        {
            var viewType = GetViewType(viewModel);
            return GetView<TViewModel>(viewType);
        }

        public UserControl ResolveView<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            var viewModelInstance = viewModel ?? dependencyInjectionService.Resolve<TViewModel>(new TypedParameter(typeof(TViewModelParameter), viewModelParameter));
            var viewType = GetViewType(viewModelInstance);
            return GetView(viewType, viewModelInstance);
        }

        private Type GetViewType<TViewModel>(TViewModel viewModel)
        {
            var viewModelType = viewModel?.GetType() ?? typeof(TViewModel);
            var viewTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace(viewModelType.Assembly.GetName().Name, typeof(MainWindow).Assembly.GetName().Name)
                .Replace("ViewModel", "View");

            var viewType = Type.GetType(viewTypeName);
            if (viewType != null)
            {
                return viewType;
            }

            throw new Exception();
        }

        private Type GetWindowType<TViewModel>(TViewModel viewModel)
        {
            var viewModelType = viewModel?.GetType() ?? typeof(TViewModel);
            var windowTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace(viewModelType.Assembly.GetName().Name, typeof(MainWindow).Assembly.GetName().Name)
                .Replace("ViewModel", "Window");

            var windowType = Type.GetType(windowTypeName);
            if (windowType != null)
            {
                return windowType;
            }

            throw new Exception();
        }

        private UserControl GetView<TViewModel>(Type viewType, TViewModel viewModel = null)
            where TViewModel : class, IViewModel
        {
            if (viewModel == null)
            {
                return dependencyInjectionService.Resolve(viewType) as UserControl;
            }

            return dependencyInjectionService.Resolve(viewType, new TypedParameter(typeof(TViewModel), viewModel)) as UserControl;
        }

        private Window GetWindow<TViewModel>(Type viewType, TViewModel viewModel = null)
            where TViewModel : class, IViewModel
        {
            if (viewModel == null)
            {
                return dependencyInjectionService.Resolve(viewType) as Window;
            }

            return dependencyInjectionService.Resolve(viewType, new TypedParameter(typeof(TViewModel), viewModel)) as Window;
        }
    }
}