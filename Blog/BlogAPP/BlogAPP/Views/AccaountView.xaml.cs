using BlogAPP.ViewModels;
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

namespace BlogAPP.Views
{
    /// <summary>
    /// Interaction logic for AccaountView.xaml
    /// </summary>
    public partial class AccaountView : UserControl
    {
        public AccaountView()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Вызовите вашу команду здесь
            if (DataContext is AccaountViewModel viewModel)
            {
                App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<FormViewModel>();
            }
        }

        private void ExecuteClickAccount(object sender, ExecutedRoutedEventArgs e)
        {
            App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<FormViewModel>();
        }
    }
}
