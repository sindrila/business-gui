using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using business_social_media.Services;

namespace bussiness_social_media.MVVM.ViewModel
{
    class UserManagedBusinessPagesViewModel : Core.ViewModel
    {
        private readonly IBusinessService _businessService;
        private INavigationService _navigation;
        private readonly AuthenticationService _authenticationService;
        private string _userId;

        public string UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToBusinessProfileViewCommand { get; set; }
        public ObservableCollection<Business> Businesses
        {
            get
            {
                // WE NEED TO CHANGE THIS TO ONLY SHOW BUSINESSES THAT THE USER OWNS
                // return new ObservableCollection<Business>(_businessService.GetBusinessesByUserId(UserId));
                return new ObservableCollection<Business>(_businessService.GetAllBusinesses());
            }
        }

        public INavigationService NavigationService
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public UserManagedBusinessPagesViewModel(INavigationService navigationService, IBusinessService businessService, AuthenticationService authenticationService)
        {
            NavigationService = navigationService;
            _businessService = businessService;
            _authenticationService = authenticationService;

            //UserId = _authenticationService.CurrentUser.Username;
            NavigateToBusinessProfileViewCommand = new RelayCommand(o =>
            {
                if (o is Business business)
                {
                    NavigationService.BusinessId = business.Id;
                    NavigationService.NavigateTo<BusinessProfileViewModel>();
                }
            }, o => true);
            _businessService = businessService;
            _businessService = businessService;
        }

       
    }
}
