using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    class BusinessProfileViewModel : Core.ViewModel
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

        public BusinessProfileViewModel(INavigationService navigationService, IBusinessService businessService)
        {
            NavigationService = navigationService;
            _businessService = businessService;
           
        }
    }
}
