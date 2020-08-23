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

namespace LAB_10
{
    /// <summary>
    /// Logika interakcji dla klasy FIleWatcher.xaml
    /// </summary>
    public partial class FIleWatcher : Window
    {
        public FIleWatcher()
        {
            InitializeComponent();
            fwtb.DataContext = _fileContents;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Changed += _watcher_Changed;
        }

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
            LoadFile();
        }

        private void LoadFile()
        {
            //throw new NotImplementedException();
            var text = File.ReadAllText(_fileContents.Path);
            _fileContents.Content = text;
        }

        private FileContent _fileContents = new FileContent();
        private FileSystemWatcher _watcher = new FileSystemWatcher();

        private void ChooseFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Wybierz plik do obserwowania",
                Filter = "Textfile|*.txt"
            };
            var result = openFileDialog.ShowDialog(this);
            if (!result.HasValue || !result.Value)
            {
                return;
            }
            _fileContents.Path = openFileDialog.FileName;
            _watcher.Path = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, string.Empty); ///chce katalog stad ten replace
            _watcher.EnableRaisingEvents = true;
            LoadFile();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadFile();
        }

        private void RefreshButton(object sender, RoutedEventArgs e)
        {
            LoadFile();
        }
    }
}
