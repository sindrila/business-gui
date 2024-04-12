﻿using business_social_media.Services;
using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bussiness_social_media.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        private AuthenticationService _authenticationService;
        public Visibility IsLoggedInMenuItemsVisibility { get; set; }

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public AuthenticationService AuthenticationService
        {
            get => _authenticationService;
            set
            {
                _authenticationService = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand NavigateToRegisterViewCommand { get; set; }


        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToCreateNewBusinessViewCommand{ get; set; }

        public RelayCommand NavigateToLoginViewCommand { get; set; }
        public RelayCommand NavigateToUserManagedBusinessesViewCommand { get; set; }
        public MainViewModel(INavigationService navigationService, AuthenticationService authenticationService)
        {
            Navigation = navigationService;
            AuthenticationService = authenticationService;
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
            NavigateToCreateNewBusinessViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateNewBusinessViewModel>(); }, o => true);
            NavigateToRegisterViewCommand = new RelayCommand(o => { Navigation.NavigateTo<RegisterViewModel>(); }, o => true);
            NavigateToLoginViewCommand = new RelayCommand(o => { Navigation.NavigateTo<LoginViewModel>(); }, o => true);
            NavigateToUserManagedBusinessesViewCommand = new RelayCommand(o =>
            {
                Navigation.NavigateTo<UserManagedBusinessPagesViewModel>();
            }, o => true);
            Navigation.NavigateTo<LoginViewModel>();
            IsLoggedInMenuItemsVisibility = Visibility.Collapsed;
            AuthenticationService.LoginStatusChanged += OnLoginStatusChanged;
        }

        private void OnLoginStatusChanged(object sender, EventArgs e)
        {
            UpdateButtonVisibility();
        }

        private void UpdateButtonVisibility()
        {
            IsLoggedInMenuItemsVisibility = AuthenticationService.getIsLoggedIn() ? Visibility.Visible : Visibility.Collapsed;
        }

    }
}
