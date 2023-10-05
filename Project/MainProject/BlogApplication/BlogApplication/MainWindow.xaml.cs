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
using BlogApplication.Repositories;
using BlogApplication.ViewModels;

namespace BlogApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            UserDapperRepository userRepository = new UserDapperRepository();
            this.viewModel = new MainViewModel();
            this.viewModel.ActiveViewModel = new LogInViewModel(userRepository);
            this.DataContext = this.viewModel;
        }

        
    }
}
