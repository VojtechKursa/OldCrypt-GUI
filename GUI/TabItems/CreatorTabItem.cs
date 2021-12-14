using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.TabItems
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
