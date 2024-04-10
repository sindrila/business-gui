using bussiness_social_media.Core;
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
        private INavigationService _navigationService;

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
        public CreateNewBusinessViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigateToHomeViewModelCommand = new RelayCommand(o => { NavigationService.NavigateTo<HomeViewModel>(); }, o => true);
            AddLogoCommand = new RelayCommand(o => { ExecuteAddPicture(); } , o => true);
            AddBannerCommand = new RelayCommand(o => { ExecuteAddPicture(); }, o => true);
        }
        private String ExecuteAddPicture()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png; |All Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                MessageBox.Show(filename);
                return filename;
            }
            else { return null; }
        }
    }
}
