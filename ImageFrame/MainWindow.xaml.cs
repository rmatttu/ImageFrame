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

namespace ImageFrame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var assembly = Application.Current.MainWindow.GetType().Assembly;
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
            Title = assembly.GetName().Name + " " + version;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var saveData = SaveDataLoader.Load();
            if (saveData.images.Count <= 0) return;
            if (!File.Exists(saveData.images[0].path)) return;
            image1.Source = new BitmapImage(new Uri(saveData.images[0].path));
        }
    }
}
