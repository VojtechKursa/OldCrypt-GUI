using System;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.Modules.IO.Text
{
    /// <summary>
    /// Interaction logic for TextOutputModule.xaml
    /// </summary>
    public partial class TextOutputModule : UserControl
    {
        public TextInputModule TextInputModule { get; set; } = null;

        public event EventHandler TextChanged;

        public TextOutputModule()
        {
            InitializeComponent();

            textModule.TextChanged += TextModule_TextChanged;
            TextChanged += TextOutputModule_TextChanged;
        }

        private void TextOutputModule_TextChanged(object sender, EventArgs e)
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

        private void B_toInput_Click(object sender, RoutedEventArgs e)
        {
            if (TextInputModule != null)
            {
                TextInputModule.Text = Text;
                Text = "";
            }
        }
    }
}
