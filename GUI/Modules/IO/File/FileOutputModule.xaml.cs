using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.Modules.IO.File
{
	/// <summary>
	/// Interaction logic for FileOutputModule.xaml
	/// </summary>
	public partial class FileOutputModule : UserControl
	{
		public event EventHandler FileNameChanged;

		public FileOutputModule()
		{
			InitializeComponent();

			fileModule.FileNameChanged += FileModule_FileNameChanged;

			FileNameChanged += FileOutputModule_FileNameChanged;
		}

		private void FileOutputModule_FileNameChanged(object sender, EventArgs e)
		{ }

		private void FileModule_FileNameChanged(object sender, EventArgs e)
		{
			FileNameChanged.Invoke(sender, e);
		}

		public string FileName
		{
			get => fileModule.FileName;
			set => fileModule.FileName = value;
		}

		private void B_browse_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog
			{
				Title = "Save to file...",
				Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
			};

			if ((bool)dialog.ShowDialog())
			{
				FileName = dialog.FileName;
			}
		}
	}
}
