using OldCrypt_GUI.Data;
using OldCrypt_GUI.GUI.Modules.CipherControls;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.TabItems
{
    /// <summary>
    /// Interaction logic for CipherTabItemContent.xaml
    /// </summary>
    public partial class CipherTabItemContent : UserControl
    {
        private CipherControl cipherControl;

        public CipherTabItemContent(CipherInfo cipherInfo)
        {
            InitializeComponent();

            textOutput.TextInputModule = textInput;

            SetCipher(cipherInfo);
        }

        private void SetCipher(CipherInfo cipherInfo)
        {
            switch (cipherInfo.Name.ToLower())
            {
                case "affine": cipherControl = new CipherControl_Affine(); break;
                case "atbash": cipherControl = new CipherControl_Atbash(); break;
                case "caesar": cipherControl = new CipherControl_Caesar(); break;
                case "latin": cipherControl = new CipherControl_Latin(); break;
                case "playfair": cipherControl = new CipherControl_Playfair(); break;
                case "polybius square": cipherControl = new CipherControl_Polybius(); break;
                case "rotation": cipherControl = new CipherControl_Rotation(); break;
                case "vigenere": cipherControl = new CipherControl_Vigenere(); break;
                case "vigenere binary": cipherControl = new CipherControl_Vigenere_Binary(); break;
                case "binary": cipherControl = new CipherControl_Binary(); break;
                case "hexadecimal": cipherControl = new CipherControl_Hexadecimal(); break;
                case "reverse": cipherControl = new CipherControl_Reverse(); break;
                case "reverse neighbors": cipherControl = new CipherControl_ReverseNeighbors(); break;
                case "scytale": cipherControl = new CipherControl_Scytale(); break;
                case "rail fence": cipherControl = new CipherControl_RailFence(); break;
                case "md5": cipherControl = new CipherControl_MD5(); break;
                case "ripemd160": cipherControl = new CipherControl_RIPEMD160(); break;
                case "sha1": cipherControl = new CipherControl_SHA1(); break;
                case "sha256": cipherControl = new CipherControl_SHA256(); break;
                case "sha384": cipherControl = new CipherControl_SHA384(); break;
                case "sha512": cipherControl = new CipherControl_SHA512(); break;
                case "aes": cipherControl = new CipherControl_AES(); break;
                case "des": cipherControl = new CipherControl_DES(); break;
                case "tripledes": cipherControl = new CipherControl_TripleDES(); break;
                case "rc2": cipherControl = new CipherControl_RC2(); break;
            }

            cipherControl.Margin = new Thickness(10, 10, 10, 286);
            cipherControl.Name = "cipherControl";
            cipherControl.ProgressModule = progressModule;
            cipherControl.StrictnessModule = strictnessModule;
            cipherControl.SetValue(Grid.ColumnProperty, 1);

            grid.Children.Add(cipherControl);

            if (!cipherInfo.BinaryAvailable)
                CB_mode.Items.RemoveAt(1);

            if (cipherInfo.Type == "Hash")
            {
                B_encrypt.Content = "Hash";
                B_decrypt.Visibility = Visibility.Hidden;
            }
        }

        private void CB_mode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_mode.SelectedIndex == 0)
            {
                textInput.Visibility = Visibility.Visible;
                textOutput.Visibility = Visibility.Visible;

                fileInput.Visibility = Visibility.Hidden;
                fileOutput.Visibility = Visibility.Hidden;

                if (cipherControl is CipherControl_Vigenere_Binary)
                {
                    grid.Children.Remove(cipherControl);
                    SetCipher(new CipherInfo("Vigenere", false, "Substitution", true));
                }
            }
            else if (CB_mode.SelectedIndex == 1)
            {
                textInput.Visibility = Visibility.Hidden;
                textOutput.Visibility = Visibility.Hidden;

                fileInput.Visibility = Visibility.Visible;
                fileOutput.Visibility = Visibility.Visible;

                if (cipherControl is CipherControl_Vigenere)
                {
                    grid.Children.Remove(cipherControl);
                    SetCipher(new CipherInfo("Vigenere binary", false, "Substitution", true));
                }
            }
        }

        private async void B_encrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CB_mode.SelectedIndex == 0) //text mode
                {
                    textOutput.Text = await cipherControl.Encrypt(textInput.Text);

                    progressModule.Progress = 100;
                }
                else if (CB_mode.SelectedIndex == 1)    //file mode
                {
                    if (File.Exists(fileInput.FileName))
                    {
                        BinaryReader reader = new BinaryReader(new FileStream(fileInput.FileName, FileMode.Open, FileAccess.Read));
                        BinaryWriter writer = new BinaryWriter(new FileStream(fileOutput.FileName, FileMode.Create, FileAccess.Write));

                        bool success = await cipherControl.Encrypt(reader, writer);

                        if (success)
                        {
                            progressModule.Progress = 100;
                            Functions.GUI.ShowSuccess("File encrypted successfully");
                        }
                        else
                            Functions.GUI.ShowError("File encryption encountered an error");
                    }
                    else
                        Functions.GUI.ShowError("Input file not found");
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private async void B_decrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CB_mode.SelectedIndex == 0) //text mode
                {
                    textOutput.Text = await cipherControl.Decrypt(textInput.Text);

                    progressModule.Progress = 100;
                }
                else if (CB_mode.SelectedIndex == 1)    //file mode
                {
                    if (File.Exists(fileInput.FileName))
                    {
                        BinaryReader reader = new BinaryReader(new FileStream(fileInput.FileName, FileMode.Open, FileAccess.Read));
                        BinaryWriter writer = new BinaryWriter(new FileStream(fileOutput.FileName, FileMode.Create, FileAccess.Write));

                        bool success = await cipherControl.Decrypt(reader, writer);

                        if (success)
                        {
                            progressModule.Progress = 100;
                            Functions.GUI.ShowSuccess("File decrypted successfully");
                        }
                        else
                            Functions.GUI.ShowError("File decryption encountered an error");
                    }
                    else
                        Functions.GUI.ShowError("Input file not found");
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ShowError(Exception exception)
        {
            string message;

            if (exception.Message == "")
                message = "Program encountered an unspecified error";
            else
                message = exception.Message;

            Functions.GUI.ShowError(message);
        }
    }
}
