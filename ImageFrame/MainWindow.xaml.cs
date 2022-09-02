using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        SaveData saveData;

        public MainWindow()
        {
            InitializeComponent();

            var assembly = Application.Current.MainWindow.GetType().Assembly;
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
            Title = assembly.GetName().Name + " " + version;

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(3.0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            saveData = SaveDataIO.Load();
            if (saveData.images.Count <= 0) return;
            if (!File.Exists(saveData.images[0].path)) return;
            image1.Source = new BitmapImage(new Uri(saveData.images[0].path));
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
            SaveDataIO.Save(saveData);
        }
    }
}
