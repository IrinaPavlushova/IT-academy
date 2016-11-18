using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

using Autofac;

namespace itacademy.gui
{
	using extentions;

	public class NModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{


			base.Load(builder);
		}
	}

	static class Program
	{
		private static IContainer CreateContainer()
		{
			var containerBuilder = new ContainerBuilder();

			containerBuilder
				.RegisterType<AppBootsrapper>()
				.As<IAppBootsrapper>();

			containerBuilder
				.RegisterType<MainFormFactory>()
				.As<IMainFormFactory>();

			containerBuilder
				.RegisterType<ViewResolver>()
				.As<IViewResolver>();
			
			containerBuilder.RegisterInstance<B>(new B());

			return containerBuilder.Build();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			using(var container = CreateContainer())
			{
				var bootstrapper = container.Resolve<IAppBootsrapper>();

				bootstrapper.Run();
			}
		}
	}
}
