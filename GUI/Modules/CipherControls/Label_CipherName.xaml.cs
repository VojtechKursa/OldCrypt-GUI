using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for Label_CipherName.xaml
    /// </summary>
    public partial class Label_CipherName : UserControl
    {
        public Label_CipherName()
        {
            InitializeComponent();
        }

        public Label_CipherName(string labelContent)
        {
            InitializeComponent();

            L_cipherName.Content = labelContent;
        }

        public string LabelContent
        {
            get => L_cipherName.Content.ToString();
            set => L_cipherName.Content = value;
        }
    }
}
