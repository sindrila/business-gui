using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    internal class BusinessProfileContactViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        private IBusinessService _businessService;

        public Business _currentBusiness;


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
        public BusinessProfileContactViewModel(INavigationService navigationService, IBusinessService businessService)
        {
            Navigation = navigationService;
            _businessService = businessService;
            NavigateToPostsCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileViewModel>(); }, o => true);
            NavigateToReviewsCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileReviewsViewModel>(); }, o => true);
            NavigateToContactCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileContactViewModel>(); }, o => true);
            NavigateToAboutCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileAboutViewModel>(); }, o => true);
            changeCurrrentBusiness();
            // In this class, you have the instance of the business in currentBusiness. You can access it in the BusinessProfileView.xaml but I'm not quite sure how. Ask chat gpt, I tried something and I do not know if it works. It is currently 00:47 and I want to go to sleep
        }

        public Business changeCurrrentBusiness()
        {
            return _businessService.GetBusinessById(_navigation.BusinessId);
        }
    }
}
