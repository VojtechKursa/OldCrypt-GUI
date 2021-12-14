using OldCrypt_Library.Old.Substitution;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for CipherControl_Affine.xaml
    /// </summary>
    public partial class CipherControl_Affine : CipherControl
    {
        public CipherControl_Affine()
        {
            InitializeComponent();

            mod_cipherName.LabelContent = "Affine";
        }

        protected override void CreateCipher()
        {
            cipher = new Affine(NUD_a.Value, NUD_b.Value);
        }
    }
}
