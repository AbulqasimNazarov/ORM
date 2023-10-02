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
using Academy.Repositories;
using Academy.ViewModels;

namespace Academy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel viewModel;
        public GroupsRepository Grepository;
        public StudentsRepository Srepository;
        public TeacherRepository Trepository;
        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = new MainWindowViewModel();
            this.viewModel.ActiveViewModel = new InfoViewModel();
            this.Grepository = new GroupsRepository();
            this.Srepository = new StudentsRepository();
            this.Trepository = new TeacherRepository();
            this.DataContext = this.viewModel;
        }

        private void ButtonInfo_OnClick(object sender, RoutedEventArgs e) =>
            this.viewModel.ActiveViewModel = new InfoViewModel();

        private void ButtonGroups_OnClick(object sender, RoutedEventArgs e) =>
            this.viewModel.ActiveViewModel = new GroupsViewModel(Grepository);

        private void ButtonStudents_OnClick(object sender, RoutedEventArgs e) =>
            this.viewModel.ActiveViewModel = new StudentsViewModel(Srepository);

        private void ButtonTeachers_OnClick(object sender, RoutedEventArgs e) => this.viewModel.ActiveViewModel = new TeachersViewModel(Trepository);
        

    }
}
