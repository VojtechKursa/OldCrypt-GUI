using OldCrypt_GUI.Data;
using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.TabItems
{
    public class CipherTabItem : TabItem
    {
        public CipherTabItem(string header, CipherInfo cipherInfo)
        {
            Header = header;
            Content = new CipherTabItemContent(cipherInfo);

            MenuItem closeButton = new MenuItem() { Header = "Close" };
            closeButton.Click += CloseButton_Click;

            ContextMenu = new ContextMenu();
            ContextMenu.Items.Add(closeButton);
        }

        private void CloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ((TabControl)Parent).Items.Remove(this);
        }
    }
}
