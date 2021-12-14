using OldCrypt_Library.Old.Substitution;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for CipherControl_Polybius.xaml
    /// </summary>
    public partial class CipherControl_Rotation : CipherControl
    {
        public CipherControl_Rotation()
        {
            InitializeComponent();

            mod_cipherName.LabelContent = "Rotation";
        }

        protected override void CreateCipher()
        {
            cipher = new Rotation(NUD_a.Value);
        }
    }
}
