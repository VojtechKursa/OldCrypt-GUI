using OldCrypt.Library.Old.Substitution;
using System.Windows;

namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	/// <summary>
	/// Interaction logic for CipherControl_Polybius.xaml
	/// </summary>
	public partial class CipherControl_Polybius : CipherControl
	{
		public CipherControl_Polybius()
		{
			InitializeComponent();

			mod_cipherName.LabelContent = "Polybius square";
		}

		protected override void CreateCipher()
		{
			cipher = new Polybius(TB_key.Text);
		}

		private void B_help_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			MessageBox.Show("Polybius square normally doesn't accept a key, but it is possible to add a key to the Polybius square table in the same way as in the Playfair code. Just keep in mind that a key isn't a 'standard' feature of the Polybius square.", "Note/Warning", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
		}
	}
}
