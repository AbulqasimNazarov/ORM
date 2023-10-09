using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using BlogAPP.ChangePicture;

namespace BlogAPP.Views
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
            
            //var bitmapImage = new BitmapImage();
            //this.ProfilImage.Source = bitmapImage.ChangePic("/Assets/defaultProfil.png");
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            //if (openFileDialog.ShowDialog() == true)
            //{
            //    try
            //    {
            //        BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
            //        ProfilImage.Source = image;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error: {ex.Message}");
            //    }
            //}
        }

    }
}
