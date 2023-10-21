using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CopyFilesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonFrom_Click(object sender, RoutedEventArgs e)
        {
            FromTextBox.Text = OpenFile();
        }

        private void buttonTo_Click(object sender, RoutedEventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            ToTextBox.Text = dialog.SelectedPath;
            
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FromTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCopy.IsEnabled = CheckFromToPath();
        }

        private void ToTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCopy.IsEnabled = CheckFromToPath();
        }

        private bool CheckFromToPath()
        {
            return ToTextBox.Text.Length > 0 && FromTextBox.Text.Length > 0;
        }

        private static string OpenFile()
        {
            var openFile = new System.Windows.Forms.OpenFileDialog
            {
                Multiselect = false
            };

            openFile.ShowDialog();

            return openFile.FileName;
        }
    }
}
