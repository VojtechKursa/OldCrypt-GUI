using System;
using System.Windows;
using System.Windows.Controls;

namespace OldCrypt.GUI.GUI.Modules
{
	/// <summary>
	/// Interaction logic for NumericUpDown.xaml
	/// </summary>
	public partial class NumericUpDown : UserControl
	{
		private int value;

		public event EventHandler ValueChanged;

		public NumericUpDown()
		{
			InitializeComponent();

			TB_value.TextChanged += TB_value_TextChanged;
			ValueChanged += NumericUpDown_ValueChanged;
		}

		private void NumericUpDown_ValueChanged(object sender, EventArgs e)
		{ }

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			UpdateSize();
		}

		public int Value
		{
			get => value;
			set
			{
				TB_value.Text = value.ToString();
				this.value = value;
			}
		}

		private void TB_value_TextChanged(object sender, TextChangedEventArgs e)
		{
			bool isNumber = false;
			int temp = 0;

			try
			{
				temp = Convert.ToInt32(TB_value.Text);
				isNumber = true;
			}
			catch { }

			if (isNumber)
			{
				value = temp;
				ValueChanged.Invoke(this, new EventArgs());
			}
			else
				TB_value.Text = value.ToString();
		}

		private void B_Up_Click(object sender, RoutedEventArgs e)
		{
			value++;
			TB_value.Text = value.ToString();
		}

		private void B_Down_Click(object sender, RoutedEventArgs e)
		{
			value--;
			TB_value.Text = value.ToString();
		}

		private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			UpdateSize();
		}

		private void UpdateSize()
		{
			if (ActualHeight != 0)
				TB_value.FontSize = ActualHeight / 2;
		}
	}
}
