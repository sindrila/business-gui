﻿using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;
namespace bussiness_social_media.MVVM.ViewModel
{
    public class CreateNewBusinessViewModel : Core.ViewModel
    {
        private IBusinessService _businessService;
        private INavigationService _navigationService;
        public event EventHandler BusinessCreated;

        private string _businessName;
        private string _businessDescription;
        private string _businessCategory;
        private string _phoneNumber;
        private string _emailAddress;
        private string _website;
        private string _address;
        private string _logo;
        private string _banner;

        public string BusinessName
        {
            get => _businessName;
            set
            {
                _businessName = value;
                OnPropertyChanged();
            }
        }

        public string BusinessDescription
        {
            get => _businessDescription;
            set
            {
                _businessDescription = value;
                OnPropertyChanged();
            }
        }

        public string BusinessCategory
        {
            get => _businessCategory;
            set
            {
                _businessCategory = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                OnPropertyChanged();
            }
        }

        public string Website
        {
            get => _website;
            set
            {
                _website = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public string Banner
        {
            get => _banner;
            set
            {
                _banner = value;
                OnPropertyChanged();
            }
        }

        public string Logo
        {
            get => _logo;
            set
            {
                _logo = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CreateBusinessCommand { get; set; }

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddLogoCommand { get; private set; }
        public ICommand AddBannerCommand {  get; private set; }
        public RelayCommand NavigateToHomeViewModelCommand { get; set; }
        public CreateNewBusinessViewModel(INavigationService navigationService, IBusinessService businessService)
        {
            NavigationService = navigationService;
            NavigateToHomeViewModelCommand = new RelayCommand(o => { NavigationService.NavigateTo<HomeViewModel>(); }, o => true);
            AddLogoCommand = new RelayCommand(o => { ExecuteAddLogo(); } , o => true);
            AddBannerCommand = new RelayCommand(o => { ExecuteAddBanner(); }, o => true);
            _businessService = businessService;

            NavigateToHomeViewModelCommand = new RelayCommand(o => { NavigationService.NavigateTo<HomeViewModel>(); }, o => true);
            CreateBusinessCommand = new RelayCommand(CreateBusiness, CanCreateBusiness);
        }
        private void ExecuteAddLogo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png; |All Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                Logo = filename;
            }
            
        }
        private void ExecuteAddBanner()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png; |All Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filename = openFileDialog.FileName;
             
                Banner = filename;
            }
        }
        
        private void CreateBusiness(object parameter)
        {
            //TO DO: ADD USERNAME OF THE USER THAT CREATED THE BUSINESS TO THE managerUsernames array in the bussines
            List<string> managerUsernames = new List<string> { "admin" };
            _businessService.AddBusiness(BusinessName, BusinessDescription, BusinessCategory, Logo, Banner, PhoneNumber, EmailAddress, Website, Address, DateTime.Now, managerUsernames);
            _navigationService.NavigateTo<HomeViewModel>();
          
        }
        
        private bool CanCreateBusiness(object parameter)
        {
            // Add validation logic here if needed
            return true;
        }

    }
}
