
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using OrmModuleProject.ViewModels;
using OrmModuleProject.Views;

namespace OrmModuleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel viewModel;
        private DispatcherTimer timer;
        
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); 
            timer.Tick += Timer_Tick;
            timer.Start();
            this.viewModel = new MainViewModel();
            this.viewModel.ActiveViewModel = new StartAppViewModel();
            this.DataContext = viewModel;
            


            UpdateTime();
        }

        private void Line_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            this.viewModel.ActiveViewModel = new LogInViewModel();
        }


        private void UpdateTime()
        {
            
            DateTime currentTime = DateTime.Now;

            
            timeTextBlock.Text = currentTime.ToString("HH:mm");
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Останавливаем таймер при закрытии окна
            timer.Stop();
        }
    }
}
