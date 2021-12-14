using OldCrypt_Library.Old.Substitution;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for CipherControl_Vigenere.xaml
    /// </summary>
    public partial class CipherControl_Vigenere : CipherControl
    {
        public CipherControl_Vigenere()
        {
            InitializeComponent();

            mod_cipherName.LabelContent = "Vigenere";
        }

        protected override void CreateCipher()
        {
            cipher = new Vigenere(TB_key.Text);
        }
    }
}
