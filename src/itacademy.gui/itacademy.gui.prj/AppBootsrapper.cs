using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itacademy.gui
{
	public interface IAppBootsrapper
	{
		void Run();
	}

	public class AppBootsrapper : IAppBootsrapper
	{
		public IMainFormFactory MainFormFactory { get; }

		public AppBootsrapper(IMainFormFactory mainFormFactory)
		{
			MainFormFactory = mainFormFactory;
		}

		public void Run()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
			Application.Run(MainFormFactory.CreateMainForm());
		}
	}
}
