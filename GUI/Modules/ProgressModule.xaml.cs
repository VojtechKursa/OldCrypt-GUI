using System;
using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.Modules
{
	/// <summary>
	/// Interaction logic for ProgressModule.xaml
	/// </summary>
	public partial class ProgressModule : UserControl
	{
		public event EventHandler ProgressChanged;

		public ProgressModule()
		{
			InitializeComponent();

			ProgressChanged += ProgressModule_ProgressChanged;
		}

		private void ProgressModule_ProgressChanged(object sender, EventArgs e)
		{ }

		/// <summary>
		/// Gets or sets the progress displayed by the <see cref="ProgressModule"/>, in %, as a number between 0 and 100.
		/// </summary>
		/// <returns>The progress displayed by the <see cref="ProgressModule"/>, in %, as a number between 0 and 100.</returns>
		public double Progress
		{
			get { return pb_progress.Value; }
			set
			{
				pb_progress.Value = value < 0 ? 0 : value > 100 ? 100 : value;

				tb_progress.Text = Math.Round(value, 2) + " %";

				ProgressChanged.Invoke(this, new EventArgs());
			}
		}
	}
}
