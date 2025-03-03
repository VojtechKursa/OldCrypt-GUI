using System.Windows;
using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.Modules
{
	/// <summary>
	/// Interaction logic for StrictnessModule.xaml
	/// </summary>
	public partial class StrictnessModule : UserControl
	{
		public StrictnessModule()
		{
			InitializeComponent();
		}

		public bool StrictMode { get => (bool)ChB_strictMode.IsChecked; }
		public bool IgnoreCase { get => (bool)ChB_ignoreCase.IsChecked; }
		public bool IgnoreSpaces { get => (bool)ChB_ignoreSpaces.IsChecked; }

		private void B_help_Click(object sender, RoutedEventArgs e)
		{
			string message = "Strict mode\n   If off, characters that can't be encrypted are passed to the output unencrypted.\n   If on, characters that can't be encrypted are dropped.\n\n" +
				"Ignore case\n   If off, case of the letters will be kept (if possible).\n   If on, all letters will be converted to uppercase.\n\n" +
				"Ignore spaces\n   If off, spaces will be kept in a way that, when decrypted, they will be in the original position.\n   If on, spaces will be ignored/dropped.\n\n" +
				"Old encryption methods usually don't support spaces, case and characters other than latin alphabet, however this program, when in non-strict mode can work with them and even encrypt them in some cases.\n" +
				"If you want the encryption methods to work realistically (the way the were designed to), check all 3 checkboxes.";

			MessageBox.Show(message, "Help", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
		}
	}
}
