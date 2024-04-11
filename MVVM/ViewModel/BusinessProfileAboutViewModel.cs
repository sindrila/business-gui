using business_social_media.Services;
using bussiness_social_media.Core;
using bussiness_social_media.MVVM.View;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    internal class BusinessProfileAboutViewModel : Core.ViewModel
    {

        private INavigationService _navigation;
        private IBusinessService _businessService;
        private AuthenticationService _authenticationService;

        public Business _currentBusiness;

        private bool _isCurrentUserManager;

        public bool IsCurrentUserManager
        {
            get
            {
                if (_authenticationService.getIsLoggedIn())
                {
                    return _businessService.IsUserManagerOfBusiness(CurrentBusiness.Id,
                        _authenticationService.CurrentUser.Username);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                _isCurrentUserManager = value;
                OnPropertyChanged(nameof(IsCurrentUserManager));
            }
        }

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public Business CurrentBusiness 
        {
            get
            {
                return changeCurrrentBusiness();
            }
            set
            {
                _currentBusiness = value;
                OnPropertyChanged(nameof(CurrentBusiness)); 
            }
        }

        public RelayCommand NavigateToPostsCommand { get; set; }
        public RelayCommand NavigateToReviewsCommand { get; set; }
        public RelayCommand NavigateToContactCommand { get; set; }
        public RelayCommand NavigateToAboutCommand { get; set; }
        public BusinessProfileAboutViewModel(INavigationService navigationService, IBusinessService businessService, AuthenticationService authenticationService)
        {
            Navigation = navigationService;
            _businessService = businessService;
            _authenticationService = authenticationService;
            NavigateToPostsCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileViewModel>(); }, o => true);
            NavigateToReviewsCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileReviewsViewModel>(); }, o => true);
            NavigateToContactCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileContactViewModel>(); }, o => true);
            NavigateToAboutCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileAboutViewModel>(); }, o => true);
            changeCurrrentBusiness();
            

        }

        public Business changeCurrrentBusiness()
        {
            return  _businessService.GetBusinessById(_navigation.BusinessId);
        }
    }
}
