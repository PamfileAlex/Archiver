using Autofac;
using AutofacSerilogIntegration;
using Serilog;

namespace Archiver.Core;
public class CoreModule : Module
{
	/// <summary>
	/// Setup for Serilog logger.
	/// </summary>
	public static void SetupLogger()
	{
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Verbose()
			.WriteTo.File("log.txt")
			.CreateLogger();
	}

	/// <inheritdoc/>
	protected override void Load(ContainerBuilder builder)
	{
		base.Load(builder);

		SetupLogger();
		builder.RegisterLogger();
	}
}
