using System.Windows;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for KeyEditor.xaml
    /// </summary>
    public partial class KeyEditor : Window
    {
        private readonly string backup;
        private readonly KeyModule_Symmetrical module;

        public KeyEditor(string initialValue, KeyModule_Symmetrical module)
        {
            InitializeComponent();

            TB_value.Text = initialValue;
            backup = initialValue;

            this.module = module;
        }

        private void B_edit_Click(object sender, RoutedEventArgs e)
        {
            B_edit.Visibility = Visibility.Hidden;
            B_close.Visibility = Visibility.Hidden;
            B_apply.Visibility = Visibility.Visible;
            B_cancel.Visibility = Visibility.Visible;

            TB_value.IsReadOnly = false;
        }

        private void B_close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void B_apply_Click(object sender, RoutedEventArgs e)
        {
            string promptText = "Are you sure you want to overwrite the current ";

            if (module.ModuleType == KeyModule_Symmetrical.KeyModuleType.Key)
                promptText += "Key?";
            else if (module.ModuleType == KeyModule_Symmetrical.KeyModuleType.IV)
                promptText += "IV?";

            if (MessageBox.Show(promptText, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                DialogResult = true;

                module.DialogReturn = TB_value.Text;
                Close();
            }
        }

        private void B_cancel_Click(object sender, RoutedEventArgs e)
        {
            B_edit.Visibility = Visibility.Visible;
            B_close.Visibility = Visibility.Visible;
            B_apply.Visibility = Visibility.Hidden;
            B_cancel.Visibility = Visibility.Hidden;

            TB_value.IsReadOnly = true;
            TB_value.Text = backup;
        }
    }
}
