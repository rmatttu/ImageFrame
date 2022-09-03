using System;
using System.Collections.Generic;
using System.IO;
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

namespace ImageFrame
{
    /// <summary>
    /// ImageWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ImageWindow : Window
    {

        DispatcherTimer timer;

        public DisplayInfo DisplayImage
        {
            get => DisplayImage; set
            {
                if (!File.Exists(value.path)) return;
                image1.Source = new BitmapImage(new Uri(value.path));
            }
        }

        public ImageWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(3.0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowStyle = WindowStyle == WindowStyle.None ? WindowStyle.SingleBorderWindow : WindowStyle.None;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            timer.Start();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            // timer canceled, reset
            timer.Stop();
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // timer canceled, reset
            timer.Stop();
            WindowStyle = WindowStyle.SingleBorderWindow;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // timer finished, reset
            timer.Stop();
            WindowStyle = WindowStyle.None;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
