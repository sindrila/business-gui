using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    internal class LoginWindowViewModel : Core.ViewModel
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

        public LoginWindowViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            Navigation.NavigateTo<LoginWindowViewModel>();
        }
    }
}
