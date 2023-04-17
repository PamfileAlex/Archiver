using System.Windows;
using Archiver.Gui.Wpf.Views;
using Autofac;

namespace Archiver.Gui.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	/// <inheritdoc/>
	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		using ILifetimeScope scope = SetupAutofac();

		var window = scope.Resolve<MainWindow>();
		window.Show();
	}

	private static ILifetimeScope SetupAutofac()
	{
		var builder = new ContainerBuilder();
		builder.RegisterModule<WpfModule>();
		var container = builder.Build();
		return container.BeginLifetimeScope();
	}
}
