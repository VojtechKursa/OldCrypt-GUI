using OldCrypt.Library.Old.Substitution;

namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	/// <summary>
	/// Interaction logic for CipherControl_Caesar.xaml
	/// </summary>
	public partial class CipherControl_Caesar : CipherControl
	{
		public CipherControl_Caesar()
		{
			InitializeComponent();

			mod_cipherName.LabelContent = "Caesar";
		}

		protected override void CreateCipher()
		{
			cipher = new Caesar(NUD_a.Value);
		}
	}
}
