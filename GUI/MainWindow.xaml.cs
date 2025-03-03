using OldCrypt.GUI.GUI.TabItems;
using System.Windows;

namespace OldCrypt.GUI.GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			tabControl.Items.Add(new CreatorTabItem(tabControl));
		}
	}
}
