using BlogAPP.ViewModels;
using BlogAPP.Views;
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

namespace BlogAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel viewModel;
        private readonly DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1.3);
            timer.Tick += Timer_Tick;
            this.viewModel = new ();
            this.DataContext = viewModel;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
            timer.Stop();

           
            this.viewModel.ActiveViewModel = new RegistrationViewModel();
        }
    }
}
