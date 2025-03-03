using OldCrypt.Library.Old.Transposition;

namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	/// <summary>
	/// Interaction logic for CipherControl_Scytale.xaml
	/// </summary>
	public partial class CipherControl_Scytale : CipherControl
	{
		public CipherControl_Scytale()
		{
			InitializeComponent();

			mod_cipherName.LabelContent = "Scytale";
		}

		protected override void CreateCipher()
		{
			cipher = new Scytale(NuD_columnCount.Value);
		}
	}
}
