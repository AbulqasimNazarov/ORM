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
using Academy.ViewModels;

namespace Academy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = new MainWindowViewModel();

            this.DataContext = this.viewModel;
        }

        private void ButtonInfo_OnClick(object sender, RoutedEventArgs e)
        {
            this.viewModel.ActiveViewModel = new InfoViewModel();

        }
        
        private void ButtonGroups_OnClick(object sender, RoutedEventArgs e)
        {
            this.viewModel.ActiveViewModel = new GroupsViewModel();

        }

        private void ButtonStudents_OnClick(object sender, RoutedEventArgs e)
        {
            this.viewModel.ActiveViewModel = new StudentsViewModel();

        }

        private void ButtonTeachers_OnClick(object sender, RoutedEventArgs e) => viewModel.ActiveViewModel = new TeachersViewModel();
        

    }
}
