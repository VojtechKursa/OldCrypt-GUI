using OldCrypt.GUI.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.TabItems
{
	/// <summary>
	/// Interaction logic for CreatorTabItemContent.xaml
	/// </summary>
	public partial class CreatorTabItemContent : UserControl
	{
		private readonly ObservableCollection<CipherInfo> ciphers = new ObservableCollection<CipherInfo>();
		private readonly TabControl tabControl;

		public CreatorTabItemContent(TabControl tabControl)
		{
			this.tabControl = tabControl;

			InitializeComponent();

			B_create.IsEnabled = false;

			Dg_dataGrid.ItemsSource = ciphers;

			ciphers.Add(new CipherInfo("Affine", false, "Substitution", true));
			ciphers.Add(new CipherInfo("Atbash", false, "Substitution", true));
			ciphers.Add(new CipherInfo("Caesar", false, "Substitution", true));
			ciphers.Add(new CipherInfo("Latin", false, "Substitution", false));
			ciphers.Add(new CipherInfo("Playfair", false, "Substitution", false));
			ciphers.Add(new CipherInfo("Polybius square", false, "Substitution", false));
			ciphers.Add(new CipherInfo("Rotation", false, "Substitution", true));
			ciphers.Add(new CipherInfo("Vigenere", false, "Substitution", true));
			ciphers.Add(new CipherInfo("Reverse", false, "Transposition", true));
			ciphers.Add(new CipherInfo("Reverse neighbors", false, "Transposition", true));
			ciphers.Add(new CipherInfo("Scytale", false, "Transposition", true));
			ciphers.Add(new CipherInfo("Rail fence", false, "Transposition", true));
			ciphers.Add(new CipherInfo("Binary", true, "Converter", false));
			ciphers.Add(new CipherInfo("Hexadecimal", true, "Converter", false));
			ciphers.Add(new CipherInfo("MD5", true, "Hash", true));
			ciphers.Add(new CipherInfo("RIPEMD160", true, "Hash", true));
			ciphers.Add(new CipherInfo("SHA1", true, "Hash", true));
			ciphers.Add(new CipherInfo("SHA256", true, "Hash", true));
			ciphers.Add(new CipherInfo("SHA384", true, "Hash", true));
			ciphers.Add(new CipherInfo("SHA512", true, "Hash", true));
			ciphers.Add(new CipherInfo("AES", true, "Symmetrical", true));
			ciphers.Add(new CipherInfo("DES", true, "Symmetrical", true));
			ciphers.Add(new CipherInfo("TripleDES", true, "Symmetrical", true));
			ciphers.Add(new CipherInfo("RC2", true, "Symmetrical", true));
		}

		private void B_create_Click(object sender, RoutedEventArgs e)
		{
			CipherInfo selectedItem = (CipherInfo)Dg_dataGrid.SelectedItem;

			CipherTabItem item = new CipherTabItem(tabControl.Items.Count + " - " + selectedItem.Name, selectedItem);
			tabControl.Items.Add(item);

			tabControl.SelectedIndex = tabControl.Items.Count - 1;
		}

		private void Dg_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			B_create.IsEnabled = Dg_dataGrid.SelectedIndex != -1;
		}
	}
}
