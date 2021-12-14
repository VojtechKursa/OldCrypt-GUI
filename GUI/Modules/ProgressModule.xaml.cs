using System;
using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.Modules
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
                if (value < 0)
                    pb_progress.Value = 0;
                else if (value > 100)
                    pb_progress.Value = 100;
                else
                    pb_progress.Value = value;

                tb_progress.Text = Math.Round(value, 2) + " %";

                ProgressChanged.Invoke(this, new EventArgs());
            }
        }
    }
}
