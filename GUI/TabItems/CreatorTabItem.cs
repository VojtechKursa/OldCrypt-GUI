using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.TabItems
{
	public class CreatorTabItem : TabItem
	{
		public CreatorTabItem(TabControl tabControl)
		{
			Header = "New cipher";
			Content = new CreatorTabItemContent(tabControl);
		}
	}
}
