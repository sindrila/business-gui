using bussiness_social_media.Services;
using bussiness_social_media.Core;
using bussiness_social_media.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace bussiness_social_media
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        

        
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            }) ;

            services.AddSingleton<IBusinessService, BusinessService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<CreateNewBusinessViewModel>();
            services.AddSingleton<UserManagedBusinessPagesViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton <BusinessProfileViewModel>();

            // TODO: this is delegation, find out what it is, or don't touch this code
            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
