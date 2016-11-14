using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace itacademy.gui
{
	public interface IViewResolver
	{
		T Resolve<T>() where T : Control;

		T Resolve<T>(params object[] parameters) where T : Control;
	}

	public class ViewResolver : IViewResolver
	{
		private IComponentContext ComponentContext { get; }

		public ViewResolver(IComponentContext componentContext)
		{
			ComponentContext = componentContext;
		}

		private void RegisterView<T>()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<T>().AsSelf().ExternallyOwned();
			builder.Update(ComponentContext.ComponentRegistry);
		}

		public T Resolve<T>() where T : Control
		{
			T view;
			if(!ComponentContext.TryResolve<T>(out view))
			{
				RegisterView<T>();
				view = ComponentContext.Resolve<T>();
			}
			return view;
		}

		public T Resolve<T>(params object[] parameters) where T : Control
		{
			if(parameters == null || parameters.Length == 0)
			{
				return Resolve<T>();
			}
			if(!ComponentContext.IsRegistered<T>())
			{
				RegisterView<T>();
			}
			return ComponentContext.Resolve<T>(parameters.Select(p => new TypedParameter(p.GetType(), p)));
		}
	}
}
