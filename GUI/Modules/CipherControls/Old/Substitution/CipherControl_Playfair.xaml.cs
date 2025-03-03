using OldCrypt.Library.Old.Substitution;

namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	/// <summary>
	/// Interaction logic for CipherControl_Playfair.xaml
	/// </summary>
	public partial class CipherControl_Playfair : CipherControl
	{
		public CipherControl_Playfair()
		{
			InitializeComponent();

			mod_cipherName.LabelContent = "Playfair";
		}

		protected override void CreateCipher()
		{
			cipher = new Playfair(TB_key.Text);
		}
	}
}
