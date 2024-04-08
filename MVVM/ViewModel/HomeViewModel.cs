using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        private IBusinessService _businessService;
        public ObservableCollection<Business> Businesses { get; set; }
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
        public RelayCommand NavigateToBusinessProfileViewCommand { get; set; }

        public HomeViewModel(INavigationService navigationService, IBusinessService businessService)
        {
            NavigationService = navigationService;
            NavigateToCreateNewBusinessViewCommand = new RelayCommand(o => { NavigationService.NavigateTo<CreateNewBusinessViewModel>(); }, o => true);

            //NavigateToBusinessProfileViewCommand = new RelayCommand(o => { NavigationService.NavigateTo<BusinessProfileViewModel>(); }, o => true);
            NavigateToBusinessProfileViewCommand = new RelayCommand(o =>
            {
                if (o is Business business)
                {
                    NavigationService.BusinessId = business.Id; // Assuming your Business model has an Id property
                    NavigationService.NavigateTo<BusinessProfileViewModel>();
                }
            }, o => true);
            _businessService = businessService;
            Businesses = new ObservableCollection<Business>(businessService.GetAllBusinesses());
        }

        private void NavigateToBusinessProfile(object parameter)
        {
            if (parameter is int businessId )
            {

                NavigationService.NavigateTo<CreateNewBusinessViewModel>();
                NavigationService.BusinessId = businessId;

                NavigateToCreateNewBusinessViewCommand = new RelayCommand(o => { NavigationService.NavigateTo<CreateNewBusinessViewModel>(); }, o => true);
            }
        }
    }
}
