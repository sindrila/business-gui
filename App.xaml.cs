using bussiness_social_media.Services;
using bussiness_social_media.Core;
using bussiness_social_media.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Configuration;
using System.Data;
using System.Windows;
using bussiness_social_media.MVVM.Model.Repository;
using System.Reflection.PortableExecutable;

namespace bussiness_social_media
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // Read XML file path from configuration
            string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;
            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath.Substring(0, index);
            xmlFilePath = Path.Combine(pathUntilBin, xmlFilePath);

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<IBusinessService, BusinessService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<CreateNewBusinessViewModel>();
            services.AddSingleton<UserManagedBusinessPagesViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<BusinessProfileViewModel>();

            // Pass xmlFilePath to your BusinessRepository constructor
            services.AddSingleton<IBusinessRepository>(provider => new BusinessRepository(xmlFilePath));

            services.AddSingleton <BusinessProfileViewModel>();
            services.AddSingleton<BusinessProfileReviewsViewModel>();
            services.AddSingleton<BusinessProfileContactViewModel>();
            services.AddSingleton<BusinessProfileAboutViewModel>();


            // Delegation
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
