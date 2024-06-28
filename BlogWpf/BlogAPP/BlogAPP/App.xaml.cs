using BlogAPP.ViewModels.Base;
using BlogAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BlogAPP.Mediators;
using BlogAPP.Mediators.Base;
using BlogAPP.Repositories;
using BlogAPP.Repositories.Base;
using SimpleInjector;
using System.Windows.Threading;

using System.Windows.Media.Imaging;
using BlogAPP.Models;
using Microsoft.Practices.Unity;



namespace BlogAPP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DispatcherTimer timer;
        public static Container Container { get; set; } = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            this.RegisterContainer();

            this.Start<MainViewModel>();

            base.OnStartup(e);
        }

        private void Start<T>() where T : ViewModelBase
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1.3);
            timer.Tick += Timer_Tick;
            var mainView = new MainWindow();
            var mainViewModel = Container.GetInstance<MainViewModel>();
            mainViewModel.ActiveViewModel = Container.GetInstance<T>();

            mainView.DataContext = mainViewModel;
            timer.Start();
            mainView.ShowDialog();
            //mainView.Close();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {

            timer.Stop();

            var mainViewModel = Container.GetInstance<MainViewModel>();
            mainViewModel.ActiveViewModel = Container.GetInstance<RegistrationViewModel>();
        }

        private void RegisterContainer()
        {
            Container.RegisterSingleton<IUserRepository, UserDapperRepository>();
            Container.Options.AllowOverridingRegistrations = true;
            Container.Register<IUserRepository, UserEFRepository>();

            Container.RegisterSingleton<IGenderRepository, UserGenderDapperRepository>();
            Container.RegisterSingleton<IMessenger, Messenger>();

            Container.RegisterSingleton<RegistrationViewModel>();
            Container.RegisterSingleton<UserRegistrationMessage>();
            Container.RegisterSingleton<SearchViewModel>();
            Container.RegisterSingleton<FormViewModel>();
            Container.RegisterSingleton<AccaountViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<User>();
            

            Container.Verify();
        }
    }
}
