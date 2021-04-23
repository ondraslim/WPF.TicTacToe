﻿using System;
using System.Windows.Controls;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.Core.IoC;
using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Interface;

namespace TicTacToe.App.Service
{
    public class MvvmLocatorService : IMvvmLocatorService
    {
        private readonly IDependencyInjectionService dependencyInjectionService;

        public MvvmLocatorService(IDependencyInjectionService dependencyInjectionService)
        {
            this.dependencyInjectionService = dependencyInjectionService;
        }

        public Page ResolveView<TViewModel>(TViewModel viewModel = default)
            where TViewModel : class, IViewModel
        {
            var viewType = GetViewType(viewModel);
            return GetView<TViewModel>(viewType);
        }

        public Page ResolveView<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
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
                .Replace(viewModelType.Assembly.GetName().Name, typeof(ViewBase).Assembly.GetName().Name)
                .Replace("ViewModel", "View");

            var viewType = Type.GetType(viewTypeName);
            if (viewType != null)
            {
                return viewType;
            }

            throw new Exception();
        }

        private Page GetView<TViewModel>(Type viewType, TViewModel viewModel = null)
            where TViewModel : class, IViewModel
        {
            if (viewModel == null)
            {
                return dependencyInjectionService.Resolve(viewType) as Page;
            }

            return dependencyInjectionService.Resolve(viewType, new TypedParameter(typeof(TViewModel), viewModel)) as Page;
        }
    }
}