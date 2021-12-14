using System.Windows;

namespace OldCrypt_GUI.Functions
{
    public static class GUI
    {
        public static void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }

        public static void ShowSuccess(string text)
        {
            MessageBox.Show(text, "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }
    }
}
