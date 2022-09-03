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
        SaveData saveData;
        List<ImageWindow> imageWindows;

        public MainWindow()
        {
            InitializeComponent();

            var assembly = Application.Current.MainWindow.GetType().Assembly;
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
            Title = assembly.GetName().Name + " " + version;
            imageWindows = new List<ImageWindow>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            saveData = SaveDataIO.Load();
            foreach (var item in saveData.images)
            {
                ImageWindow window = new ImageWindow();
                window.DisplayImage = item;
                window.Show();
                imageWindows.Add(window);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var item in imageWindows)
            {
                item.Close();
            }
            SaveDataIO.Save(saveData);
        }
    }
}
