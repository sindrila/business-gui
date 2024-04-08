using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    public class CreateNewBusinessViewModel : Core.ViewModel
    {
        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHomeViewModelCommand { get; set; }
        public CreateNewBusinessViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigateToHomeViewModelCommand = new RelayCommand(o=> {  NavigationService.NavigateTo<HomeViewModel>(); }, o => true);
        }
    }
}
