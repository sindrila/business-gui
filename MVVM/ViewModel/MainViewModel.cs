using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand NavigateToRegisterViewCommand { get; set; }


        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToCreateNewBusinessViewCommand{ get; set; }

        public RelayCommand NavigateToLoginViewCommand { get; set; }
        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
            NavigateToCreateNewBusinessViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateNewBusinessViewModel>(); }, o => true);
            NavigateToRegisterViewCommand = new RelayCommand(o => { Navigation.NavigateTo<RegisterViewModel>(); }, o => true);
            NavigateToLoginViewCommand = new RelayCommand(o => { Navigation.NavigateTo<LoginViewModel>(); }, o => true);
            Navigation.NavigateTo<HomeViewModel>();
        }
    }
}
