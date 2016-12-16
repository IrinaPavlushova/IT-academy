using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using itacademy.gui.Logging;

namespace itacademy.gui
{
	/// <summary>Главная форма приложения.</summary>
	public partial class MainForm : Form
	{
		#region Data

		private readonly A _a;

		#endregion

		#region .ctor

		/// <summary>Создает <see cref="MainForm"/>.</summary>
		public MainForm()
		{
			_a = new A(new B());

			InitializeComponent();

			Font = SystemFonts.MessageBoxFont;
			BackColor = SystemColors.Window;
		}

		#endregion

		protected override void OnLoad(EventArgs e)
		{
			MinimumSize = Size;
			MaximumSize = Size;
			base.OnLoad(e);

			
		}

		#region Handlers

		private void OnButtonTestClick(object sender, EventArgs e)
		{
			try
			{
				//var x = 5.5;
				//var y = 7.6;

				//A.Swap<double>(ref x, ref y);

				//var p = $"Значение x={5} значение y={7}";

				//Debug.WriteLine($@"x={x}, y={y}");

				//var str = "123fff";
				//int a;
				//a = int.Parse(str);
				//{
				//	Debug.WriteLine("OK");
				//}

				using(var dialogForm = new DialogFormTest1())
				{
					switch(dialogForm.ShowDialog(this))
					{
						case DialogResult.OK:
							{

								break;
							}
						default:
						case DialogResult.Cancel:
							{
								break;
							}
					}
				}
			}
			catch(Exception exc)
			{
				MessageBox.Show(this, exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		private void OnButtonProgressBar(object sender, EventArgs e)
		{
			var progress = new Progress<ProgressArgs>();

			using(var progressForm = new ProgressForm(progress))
			{
				progressForm.Shown += async (_1, _2) =>
				{
					await TestAsyncProgressMethods.TestProgress(progress);
					progressForm.Close();
				};
				
				switch(progressForm.ShowDialog(this))
				{
					default:
					case DialogResult.Cancel:
						{
							break;
						}
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void OnButtonTestLog_Click(object sender, EventArgs e)
		{
			try
			{
				int j = -1;
				j++;
				int i = 1 / j;
			}
			catch(Exception ex)
			{
				LogCreator.Log.Error(ex);
				LogCreator.Log.Fatal("You've been slain!", ex);
				LogCreator.Log.Info("You are dumb – divizion by zero.");
				LogCreator.Log.Warning("Prepare Uranus", ex);
				LogCreator.Log.Error("Qwerty", ex);
				MessageBox.Show(this, "Олярм!111 Mistake");
			}
		}
	}
}
