using OrmModuleProject.ViewModels.Base;
using OrmModuleProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;
using Container = SimpleInjector.Container;

namespace OrmModuleProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; } = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            this.RegisterContainer();

            this.Start<StartAppViewModel>();

            base.OnStartup(e);
        }

        public void Start<T>() where T : ViewModelBase
        {
            var mainView = new MainWindow();
            var mainViewModel = Container.GetInstance<MainViewModel>();
            mainViewModel.ActiveViewModel = Container.GetInstance<T>();

            mainView.DataContext = mainViewModel;

            mainView.ShowDialog();
        }

        private void RegisterContainer()
        {
            //Container.RegisterSingleton<IProductRepository, ProductDapperRepository>();
            //Container.RegisterSingleton<IProductStatusRepository, ProductStatusDapperRepository>();
            //Container.RegisterSingleton<IMessenger, Messenger>();

            //Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<LogInViewModel>();
            Container.RegisterSingleton<StartAppViewModel>();
            Container.RegisterSingleton<MainViewModel>();

            Container.Verify();
        }
    }
}
