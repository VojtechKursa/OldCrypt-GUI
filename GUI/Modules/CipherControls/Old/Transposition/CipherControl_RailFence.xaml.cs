using OldCrypt_Library.Old.Transposition;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for CipherControl_RailFence.xaml
    /// </summary>
    public partial class CipherControl_RailFence : CipherControl
    {
        public CipherControl_RailFence()
        {
            InitializeComponent();

            mod_cipherName.LabelContent = "Rail fence";
        }

        protected override void CreateCipher()
        {
            cipher = new RailFence(NuD_rowCount.Value);
        }
    }
}
