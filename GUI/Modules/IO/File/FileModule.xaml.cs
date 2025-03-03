using System;
using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.Modules.IO.File
{
	/// <summary>
	/// Interaction logic for FileModule.xaml
	/// </summary>
	public partial class FileModule : UserControl
	{
		public event EventHandler FileNameChanged;

		public FileModule()
		{
			InitializeComponent();

			FileNameChanged += FileModule_FileNameChanged;
		}

		private void FileModule_FileNameChanged(object sender, EventArgs e)
		{ }

		public string FileName
		{
			get => TB_filename.Text;
			set
			{
				TB_filename.Text = value;
				FileNameChanged.Invoke(this, new EventArgs());
			}
		}
	}
}
