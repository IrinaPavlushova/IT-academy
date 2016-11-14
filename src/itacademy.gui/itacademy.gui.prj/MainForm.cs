using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
	}
}
