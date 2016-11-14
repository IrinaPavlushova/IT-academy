using System;
using System.Windows.Forms;

namespace itacademy.gui
{
	public interface IMainFormFactory
	{
		Form CreateMainForm();
	}

	public class MainFormFactory : IMainFormFactory
	{
		private IViewResolver ViewResolver { get; }

		public MainFormFactory(IViewResolver viewResolver)
		{
			ViewResolver = viewResolver;
		}

		public Form CreateMainForm()
		{
			return ViewResolver.Resolve<MainForm>();
		}
	}
}
