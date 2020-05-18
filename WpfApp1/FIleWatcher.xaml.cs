using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy FileWatcher.xaml
    /// </summary>
    public partial class FileWatcher : Window //moze tu jest cos nie tak?
    {
        public FileWatcher()
        {
            InitializeComponent();

            FileContent.DataContext = fileContent;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += Watcher_Changed;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            LoadFilePath();
        }

        private FileContent fileContent = new FileContent();
        private FileSystemWatcher watcher = new FileSystemWatcher();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Wybierz plik",
                Filter = "TextFile|*txt"
            };

            var result = fileDialog.ShowDialog(this); //czemu wywalalo bledy z this?
            if (!result.HasValue || !result.Value)
            {
                return;
            }

            fileContent.Path = fileDialog.FileName;
            watcher.Path = fileDialog.FileName.Replace(fileDialog.SafeFileName, string.Empty);
            watcher.EnableRaisingEvents = true;
            LoadFilePath();
        }

        private void LoadFilePath()
        {
            var text = File.ReadAllText(fileContent.Path);
            fileContent.Content = text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadFilePath();
        }
    }
}