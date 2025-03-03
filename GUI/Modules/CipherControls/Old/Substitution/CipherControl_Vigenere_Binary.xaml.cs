using Microsoft.Win32;
using OldCrypt.Library.Old.Substitution;
using System;
using System.IO;

namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	/// <summary>
	/// Interaction logic for CipherControl_Vigenere_Binary.xaml
	/// </summary>
	public partial class CipherControl_Vigenere_Binary : CipherControl
	{
		private string fileName = null;

		public CipherControl_Vigenere_Binary()
		{
			InitializeComponent();

			mod_cipherName.LabelContent = "Vigenere (Binary)";
		}

		protected override void CreateCipher()
		{
			if (fileName != null)
			{
				if (File.Exists(fileName))
				{
					BinaryReader reader;
					try
					{
						reader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));
					}
					catch
					{
						throw new Exception("Program encountered an error during opening of the key file.");
					}

					if (reader != null)
					{
						byte[] key = reader.ReadBytes((int)new FileInfo(fileName).Length);
						reader.Close();

						cipher = new Vigenere(key);
					}
				}
				else
				{
					throw new Exception("Specified key file was not found.");
				}
			}
			else
			{
				throw new Exception("Key file not specified.");
			}
		}

		private void B_browse_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog
			{
				Title = "Select a key file",
				CheckFileExists = true
			};

			if ((bool)dialog.ShowDialog())
			{
				fileName = dialog.FileName;

				string[] nameSplit = fileName.Split(new char[] { '\\', '/' });
				TB_key.Text = nameSplit[nameSplit.Length - 1];
			}
		}
	}
}
