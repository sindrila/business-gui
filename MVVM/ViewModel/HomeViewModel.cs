using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService NavigationService
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
       
        public RelayCommand NavigateToCreateNewBusinessViewCommand { get; set; }
        public HomeViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigateToCreateNewBusinessViewCommand = new RelayCommand(o => { NavigationService.NavigateTo<CreateNewBusinessViewModel>(); }, o => true);
        }
    }
}
