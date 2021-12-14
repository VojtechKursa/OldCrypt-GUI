using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.Modules.IO.Text
{
    /// <summary>
    /// Interaction logic for TextInputModule.xaml
    /// </summary>
    public partial class TextInputModule : UserControl
    {
        public event EventHandler TextChanged;

        public TextInputModule()
        {
            InitializeComponent();

            textModule.TextChanged += TextModule_TextChanged;
            TextChanged += TextInputModule_TextChanged;
        }

        private void TextInputModule_TextChanged(object sender, EventArgs e)
        { }

        public string Text
        {
            get => textModule.Text;
            set => textModule.Text = value;
        }

        private void TextModule_TextChanged(object sender, EventArgs e)
        {
            TextChanged.Invoke(sender, e);
        }

        private void B_load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Open a file...",
                Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if ((bool)dialog.ShowDialog())
            {
                StreamReader reader = new StreamReader(dialog.FileName);
                textModule.Text = reader.ReadToEnd();
                reader.Close();
            }
        }
    }
}
