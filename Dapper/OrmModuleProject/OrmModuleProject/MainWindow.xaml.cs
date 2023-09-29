
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

namespace OrmModuleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer1;
        private DispatcherTimer timer2;
        private double progressValue = 100;
        public MainWindow()
        {
            InitializeComponent();
            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromSeconds(5); 
            timer1.Tick += Timer_Tick;
            timer1.Start();


            timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += Timer_Tick;
            timer2.Start();
            UpdateTime();
        }


        

        private void UpdateTime()
        {
            
            DateTime currentTime = DateTime.Now;

            
            timeTextBlock.Text = currentTime.ToString("HH:mm");
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();

            progressValue -= 10;
            this.ZaradkaBar.Value = progressValue;
            


            if (progressValue <= 0)
            {
                timer1.Stop();
            }
        }
    }
}
