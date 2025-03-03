using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.Modules.IO.Text
{
	/// <summary>
	/// Interaction logic for TextModule.xaml
	/// </summary>
	public partial class TextModule : UserControl
	{
		public event EventHandler TextChanged;

		public TextModule()
		{
			InitializeComponent();

			TextChanged += TextModule_TextChanged;
		}

		private void TextModule_TextChanged(object sender, EventArgs e)
		{ }

		public string Text
		{
			get => TB_text.Text;
			set => TB_text.Text = value;
		}

		private void B_save_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog
			{
				Title = "Open a file...",
				Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*"
			};

			if ((bool)dialog.ShowDialog())
			{
				StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8);
				writer.Write(TB_text.Text);
				writer.Close();
			}
		}

		private void TB_text_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextChanged.Invoke(this, new EventArgs());
		}
	}
}
