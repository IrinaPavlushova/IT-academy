using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			using(var mainForm = MainFormFactory.CreateMainForm())
			{
				mainForm.ShowDialog();
			}
		}
	}
}
