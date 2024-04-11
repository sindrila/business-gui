using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging; // Need to include this for ImageSource

namespace bussiness_social_media.MVVM.ViewModel
{
    internal class BusinessProfileReviewsViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        private IBusinessService _businessService;
        private Business _currentBusiness;
        private Review _currentReview;

        // Property to hold the image source of the current business
        private ImageSource _businessImage;
        private string _reviewDescription;
        public string ReviewDescription
        {
            get { return _reviewDescription; }
            set
            {
                _reviewDescription = value;
                OnPropertyChanged(nameof(ReviewDescription));
            }
        }
        public ImageSource BusinessImage
        {
            get { return new BitmapImage(new Uri(CurrentBusiness.Logo)); }
            set
            {
                _businessImage = value;
                OnPropertyChanged(nameof(BusinessImage));
            }
        }

        public Business CurrentBusiness
        {
            get { return ChangeCurrentBusiness(); }
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

        public RelayCommand NavigateToPostsCommand { get; set; }
        public RelayCommand NavigateToReviewsCommand { get; set; }
        public RelayCommand NavigateToContactCommand { get; set; }
        public RelayCommand NavigateToAboutCommand { get; set; }
        public RelayCommand LeaveReviewCommand { get; set; }

        public BusinessProfileReviewsViewModel(INavigationService navigationService, IBusinessService businessService)
        {
            Navigation = navigationService;
            _businessService = businessService;
            NavigateToPostsCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileViewModel>(); }, o => true);
            NavigateToReviewsCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateNewBusinessViewModel>(); }, o => true);
            NavigateToContactCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileContactViewModel>(); }, o => true);
            NavigateToAboutCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileAboutViewModel>(); }, o => true);
            LeaveReviewCommand = new RelayCommand(o => { LeaveReview(); }, o => true);
            _currentBusiness = ChangeCurrentBusiness();
            ImageSource img = new BitmapImage(new Uri(_currentBusiness.Logo));
            BusinessImage = img; 
            
        }
        private void LeaveReview()
        {
            Review review = new Review();
            review.SetBusinessId(_currentBusiness.Id);
            review.SetComment(ReviewDescription);

        }
        public Business ChangeCurrentBusiness()
        {
            return _businessService.GetBusinessById(_navigation.BusinessId);
        }
    }
}
