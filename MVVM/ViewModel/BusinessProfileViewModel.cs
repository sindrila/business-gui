using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace bussiness_social_media.MVVM.ViewModel
{
    class BusinessProfileViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        private IBusinessService _businessService;
        
        public ObservableCollection<Business> Businesses { get; set; }
        public Business currentBusiness;

        public INavigationService NavigationService
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public BusinessProfileViewModel(INavigationService navigationService, IBusinessService businessService)
        {
            _navigation = navigationService;
            _businessService = businessService;
            changeCurrrentBusiness();
            // In this class, you have the instance of the business in currentBusiness. You can access it in the BusinessProfileView.xaml but I'm not quite sure how. Ask chat gpt, I tried something and I do not know if it works. It is currently 00:47 and I want to go to sleep
        }

        public void changeCurrrentBusiness()
        {
            currentBusiness = _businessService.GetBusinessById(_navigation.BusinessId);
        }

    }
}
