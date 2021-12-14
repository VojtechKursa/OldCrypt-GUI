using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.Modules.IO.File
{
    /// <summary>
    /// Interaction logic for FileInputModule.xaml
    /// </summary>
    public partial class FileInputModule : UserControl
    {
        public event EventHandler FileNameChanged;

        public FileInputModule()
        {
            InitializeComponent();

            fileModule.FileNameChanged += FileModule_FileNameChanged;
            FileNameChanged += FileInputModule_FileNameChanged;
        }

        private void FileInputModule_FileNameChanged(object sender, EventArgs e)
        { }

        private void FileModule_FileNameChanged(object sender, EventArgs e)
        {
            FileNameChanged.Invoke(sender, e);
        }

        public string FileName
        {
            get => fileModule.FileName;
            set => fileModule.FileName = value;
        }

        private void B_browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Open a file...",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if ((bool)dialog.ShowDialog())
            {
                FileName = dialog.FileName;
            }
        }
    }
}
