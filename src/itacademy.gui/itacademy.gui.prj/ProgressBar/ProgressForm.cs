using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itacademy.gui
{
	public partial class ProgressForm : Form
	{
		public ProgressForm(Progress<ProgressArgs> progress)
		{
			InitializeComponent();

			Font = SystemFonts.MessageBoxFont;

			_progressBar.Style = ProgressBarStyle.Continuous;

			progress.ProgressChanged += OnProgressChanged;
		}

		private void OnProgressChanged(object sender, ProgressArgs e)
		{
			_progressBar.Value = e.Percent;
			_lblText.Text = e.Text;
		}

		private void ProgressForm_Load(object sender, EventArgs e)
		{
		}

		private void OnCancelClick(object sender, EventArgs e)
		{
			
		}
	}
}
