using System;
using System.Linq;
using System.Reflection;
using Archiver.Core;
using Archiver.Gui.Wpf.ViewModels;
using Archiver.Gui.Wpf.Views;
using Autofac;
using Module = Autofac.Module;

namespace Archiver.Gui.Wpf;
public class WpfModule : Module
{
	/// <inheritdoc/>
	protected override void Load(ContainerBuilder builder)
	{
		base.Load(builder);

		builder.RegisterModule<CoreModule>();

		builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.Where(FilterViewsAndViewModels)
				.AsSelf();
	}

	private static bool FilterViewsAndViewModels(Type type)
	{
		return type.GetInterfaces()
			.Any(t =>
				t.Equals(typeof(IView))
				|| t.Equals(typeof(IViewModel))
			);
	}
}
