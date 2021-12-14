namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for CipherControl_LabelOnly.xaml
    /// </summary>
    public abstract partial class CipherControl_LabelOnly : CipherControl
    {
        public CipherControl_LabelOnly(string labelContent)
        {
            InitializeComponent();

            mod_cipherName.LabelContent = labelContent;
        }
    }
}
