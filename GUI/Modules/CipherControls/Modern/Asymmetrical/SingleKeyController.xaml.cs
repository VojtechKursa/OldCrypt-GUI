using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using OldCrypt_Library.Modern.Asymmetrical;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for SingleKeyController.xaml
    /// </summary>
    public partial class SingleKeyController : UserControl
    {
        public enum ControllerType { Public, Private }

        AsymmetricalCipher Cipher { get; set; }
        ControllerType type;

        public SingleKeyController()
        {
            InitializeComponent();
        }

        public ControllerType Type
        {
            get { return type; }
            set
            {
                type = value;
                if (value == ControllerType.Public)
                    L_keyName.Content = "Public:";
                else if (value == ControllerType.Private)
                    L_keyName.Content = "Private:";
            }
        }

        private void SetFileDialog(FileDialog dialog)
        {
            dialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

            if (type == ControllerType.Public)
            {
                dialog.Title = "Select a Public Key file...";
                dialog.Filter = "Public Key file (*.publickey)|*.publickey|" + dialog.Filter;
            }
            else if (type == ControllerType.Private)
            {
                dialog.Title = "Select a Private Key file...";
                dialog.Filter = "Private Key file (*.privatekey)|*.privatekey|" + dialog.Filter;
            }
        }

        private async void B_load_Click(object sender, RoutedEventArgs e)
        {
            /*
            OpenFileDialog dialog = new OpenFileDialog()
            {
                CheckFileExists = true,
                Multiselect = false,
            };

            SetFileDialog(dialog);

            if ((bool)dialog.ShowDialog())
            {
                string result = null;

                try
                {
                    result = await Functions.IO.ReadFile(dialog.FileName);
                }
                catch
                {
                    Functions.GUI.ShowError("Error while reading the file.");
                }

                if (result != null)
                {
                    string key = Functions.RSA.GetKeyString(result, type == ControllerType.Public);

                    ((RSA)Cipher).SetParametersXML
                }
            }
            */
        }

        private async void B_save_Click(object sender, RoutedEventArgs e)
        {
            /*
            SaveFileDialog dialog = new SaveFileDialog()
            {
                AddExtension = true,
            };

            SetFileDialog(dialog);

            dialog.Title = dialog.Title.Replace("Select", "Save");

            if ((bool)dialog.ShowDialog())
            {
                try
                {
                    if (ModuleType == KeyModuleType.Key)
                    {
                        await Functions.IO.WriteFile(dialog.FileName, OldCrypt_Library.Functions.ToHex(Cipher.Key));
                        Functions.GUI.ShowSuccess("Key saved successfully.");
                    }
                    else if (ModuleType == KeyModuleType.IV)
                    {
                        await Functions.IO.WriteFile(dialog.FileName, OldCrypt_Library.Functions.ToHex(Cipher.IV));
                        Functions.GUI.ShowSuccess("IV saved successfully.");
                    }
                }
                catch
                {
                    Functions.GUI.ShowError("Error while writing to a file.");
                }
            }
            */
        }

        private void B_show_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
