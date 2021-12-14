using Microsoft.Win32;
using OldCrypt_Library.Modern.Symmetrical;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for KeyModule.xaml
    /// </summary>
    public partial class KeyModule_Symmetrical : UserControl
    {
        #region Enums

        public enum KeyModuleType { Key, IV }

        #endregion

        #region Values and Properties

        private KeyModuleType moduleType;
        public SymmetricalCipher Cipher { get; set; }
        public string DialogReturn { get; set; }

        #endregion

        #region Constructors

        public KeyModule_Symmetrical()
        {
            InitializeComponent();
        }

        #endregion

        #region Getters and Setters

        public KeyModuleType ModuleType
        {
            get { return moduleType; }
            set
            {
                moduleType = value;

                if (moduleType == KeyModuleType.Key)
                    L_label.Content = "Key:";
                else if (moduleType == KeyModuleType.IV)
                    L_label.Content = "IV:";
            }
        }

        #endregion

        #region Methods

        private void SetFileDialog(FileDialog dialog)
        {
            dialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

            if (ModuleType == KeyModuleType.Key)
            {
                dialog.Title = "Select a Key file...";
                dialog.Filter = "Key file (*.key)|*.key|" + dialog.Filter;
            }
            else if (ModuleType == KeyModuleType.IV)
            {
                dialog.Title = "Select an IV file...";
                dialog.Filter = "IV file (*.iv)|*.iv|" + dialog.Filter;
            }
        }

        #endregion

        #region Event handlers

        private async void B_load_Click(object sender, RoutedEventArgs e)
        {
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
                    result = result.Replace(" ", "");
                    result = result.Replace("\n", "");
                    result = result.Replace("\r", "");

                    byte[] resultBin = null;

                    try
                    {
                        resultBin = OldCrypt_Library.Functions.ToByte(result);
                    }
                    catch
                    {
                        Functions.GUI.ShowError("Error while converting the content of the file.");
                    }

                    if (resultBin != null)
                    {
                        try
                        {
                            if (ModuleType == KeyModuleType.Key)
                            {
                                Cipher.Key = resultBin;
                                Functions.GUI.ShowSuccess("Key loaded successfully.");
                            }
                            else if (ModuleType == KeyModuleType.IV)
                            {
                                Cipher.IV = resultBin;
                                Functions.GUI.ShowSuccess("IV loaded successfully.");
                            }

                        }
                        catch
                        {
                            Functions.GUI.ShowError("The read data resulted in Key/IV of length that is not supported by the current algorithm.");
                        }
                    }
                }
            }
        }

        private async void B_save_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void B_show_Click(object sender, RoutedEventArgs e)
        {
            string initialValue;
            byte[] temp = null;

            if (ModuleType == KeyModuleType.Key)
                temp = Cipher.Key;
            else if (ModuleType == KeyModuleType.IV)
                temp = Cipher.IV;

            initialValue = OldCrypt_Library.Functions.ToHex(temp);

            KeyEditor keyEditor = new KeyEditor(initialValue, this);

            if ((bool)keyEditor.ShowDialog())
            {
                byte[] value = null;
                try
                {
                    value = OldCrypt_Library.Functions.ToByte(DialogReturn);
                }
                catch
                {
                    Functions.GUI.ShowError("Error while converting from hexadecimal to binary.\nThe input was propably not in correct hexadecimal format.");
                }

                if (value != null)
                {
                    try
                    {
                        if (ModuleType == KeyModuleType.Key)
                        {
                            Cipher.Key = value;
                            Functions.GUI.ShowSuccess("Key replaced successfully.");
                        }
                        else if (ModuleType == KeyModuleType.IV)
                        {
                            Cipher.IV = value;
                            Functions.GUI.ShowSuccess("IV replaced successfully.");
                        }
                    }
                    catch
                    {
                        Functions.GUI.ShowError("The entered Key/IV had invalid size for the current algorithm.");
                    }
                }
            }

            DialogReturn = null;
        }

        private void B_generate_Click(object sender, RoutedEventArgs e)
        {
            if (ModuleType == KeyModuleType.Key)
            {
                Cipher.GenerateKey();
                Functions.GUI.ShowSuccess("New Key generated successfully.");
            }
            else if (ModuleType == KeyModuleType.IV)
            {
                Cipher.GenerateIV();
                Functions.GUI.ShowSuccess("New IV generated successfully.");
            }
        }

        #endregion
    }
}
