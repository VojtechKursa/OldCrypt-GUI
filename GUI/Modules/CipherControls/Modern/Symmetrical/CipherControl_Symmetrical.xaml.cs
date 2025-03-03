using OldCrypt.Library.Modern.Symmetrical;
using System;
using System.Security.Cryptography;
using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	/// <summary>
	/// Interaction logic for CipherControl_Symmetrical.xaml
	/// </summary>
	public abstract partial class CipherControl_Symmetrical : CipherControl
	{
		protected SymmetricalCipher tempCipher;

		public CipherControl_Symmetrical(string algorithmName)
		{
			CreateTempCipher();

			InitializeComponent();

			L_cipherName.Content = algorithmName;

			KM_key.ModuleType = KeyModule_Symmetrical.KeyModuleType.Key;
			KM_iv.ModuleType = KeyModule_Symmetrical.KeyModuleType.IV;
			KM_key.Cipher = tempCipher;
			KM_iv.Cipher = tempCipher;

			InitializeComboBoxes();
		}

		#region ComboBox Initialization

		private void InitializeComboBoxes()
		{
			Initialize_CB_mode();
			Initialize_CB_padding();
			Initialize_CB_blockSize();
			Initialize_CB_keySize();
		}

		private void Initialize_CB_mode()
		{
			CB_mode.Items.Clear();

			//Test if the cipher algorithm supports the cipher mode and if yes, add it.
			try
			{
				tempCipher.CipherMode = CipherMode.ECB;
				CB_mode.Items.Add("ECB");
			}
			catch { }

			try
			{
				tempCipher.CipherMode = CipherMode.CBC;
				CB_mode.Items.Add("CBC");
			}
			catch { }

			try
			{
				tempCipher.CipherMode = CipherMode.CFB;
				CB_mode.Items.Add("CFB");
			}
			catch { }

			try
			{
				tempCipher.CipherMode = CipherMode.OFB;
				CB_mode.Items.Add("OFB");
			}
			catch { }

			try
			{
				tempCipher.CipherMode = CipherMode.CTS;
				CB_mode.Items.Add("CTS");
			}
			catch { }

			CB_mode.SelectedIndex = 2;
		}

		private void Initialize_CB_padding()
		{
			CB_padding.Items.Clear();
			CB_padding.Items.Add("None");
			CB_padding.Items.Add("Zeros");
			CB_padding.Items.Add("ANSIX923");
			CB_padding.Items.Add("ISO10126");
			CB_padding.Items.Add("PKCS7");
			CB_padding.SelectedIndex = 4;
		}

		private void Initialize_CB_blockSize()
		{
			CB_blockSize.Items.Clear();
			KeySizes[] blockSizes = tempCipher.ValidBlockSizes;
			foreach (KeySizes size in blockSizes)
			{
				if (size.SkipSize == 0)
					CB_blockSize.Items.Add(new ComboBoxItem() { Content = size.MinSize / 8 });
				else
				{
					for (int i = size.MinSize; i <= size.MaxSize; i += size.SkipSize)
					{
						CB_blockSize.Items.Add(new ComboBoxItem() { Content = i / 8 });
					}
				}
			}
			CB_blockSize.SelectedIndex = 0;
		}

		private void Initialize_CB_keySize()
		{
			CB_keySize.Items.Clear();
			KeySizes[] keySizes = tempCipher.ValidKeySizes;
			foreach (KeySizes size in keySizes)
			{
				if (size.SkipSize == 0)
					CB_keySize.Items.Add(new ComboBoxItem() { Content = size.MinSize });
				else
				{
					for (int i = size.MinSize; i <= size.MaxSize; i += size.SkipSize)
					{
						CB_keySize.Items.Add(new ComboBoxItem() { Content = i });
					}
				}
			}
			CB_keySize.SelectedIndex = 0;
		}

		#endregion

		/// <summary>
		/// Must me overridden in a derived class and must assign a value to the <see cref="tempCipher"/> variable based on the specific cipher the CipherControl is for.
		/// </summary>
		protected abstract void CreateTempCipher();

		protected override void CreateCipher()
		{
			tempCipher.ClearEncryptor();
			tempCipher.ClearDecryptor();

			cipher = tempCipher;
		}

		#region Event handlers

		private void CB_keySize_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (CB_keySize.SelectedItem != null)
				tempCipher.KeySize = Convert.ToInt32(((ComboBoxItem)CB_keySize.SelectedItem).Content);
		}

		private void CB_blockSize_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (CB_blockSize.SelectedItem != null)
				tempCipher.BlockSizeByte = Convert.ToInt32(((ComboBoxItem)CB_blockSize.SelectedItem).Content);
		}

		private void CB_mode_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (CB_mode.SelectedItem != null)
			{
				switch (CB_mode.SelectedItem)
				{
					case "ECB": tempCipher.CipherMode = CipherMode.ECB; break;
					case "CBC": tempCipher.CipherMode = CipherMode.CBC; break;
					case "CFB": tempCipher.CipherMode = CipherMode.CFB; break;
					case "OFB": tempCipher.CipherMode = CipherMode.OFB; break;
					case "CTS": tempCipher.CipherMode = CipherMode.CTS; break;
				}
			}
		}

		private void CB_padding_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (CB_padding.SelectedItem != null)
			{
				switch (CB_padding.SelectedItem)
				{
					case "None": tempCipher.PaddingMode = PaddingMode.None; break;
					case "Zeros": tempCipher.PaddingMode = PaddingMode.Zeros; break;
					case "ANSIX923": tempCipher.PaddingMode = PaddingMode.ANSIX923; break;
					case "ISO10126": tempCipher.PaddingMode = PaddingMode.ISO10126; break;
					case "PKCS7": tempCipher.PaddingMode = PaddingMode.PKCS7; break;
				}
			}
		}

		#endregion
	}
}
