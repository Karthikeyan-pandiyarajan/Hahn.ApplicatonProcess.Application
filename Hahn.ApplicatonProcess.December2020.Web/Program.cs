using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		//public static IHostBuilder CreateHostBuilder(string[] args) =>
		//	Host.CreateDefaultBuilder(args)
		//		.ConfigureWebHostDefaults(webBuilder =>
		//		{
		//			webBuilder.UseStartup<Startup>();
		//		});
		public static IWebHost BuildWebHost(string[] args)
		{
			var configSettings = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();

			Log.Logger = new LoggerConfiguration()
				.WriteTo.File(configSettings["Logging:LogPath"], 
				rollingInterval: RollingInterval.Day, 
				rollOnFileSizeLimit: true, 
				fileSizeLimitBytes: 100000,
				retainedFileCountLimit: 100)
				.CreateLogger();

			return WebHost.CreateDefaultBuilder(args)
			.UseKestrel()
			.UseIISIntegration()
			.ConfigureAppConfiguration(config =>
			{
				config.AddConfiguration(configSettings);
			})
			.ConfigureLogging(logging =>
			{
				logging.AddSerilog();
				logging.AddFilter("System", LogLevel.Error)
					.AddFilter<Microsoft.Extensions.Logging.Debug.DebugLoggerProvider>("Microsoft", LogLevel.Information);
			})
			.UseStartup<Startup>()
			.Build();

			//.ConfigureLogging(logging =>
			//	logging.AddFilter("System", LogLevel.Error)
			//		.AddFilter<Microsoft.Extensions.Logging.Debug.DebugLoggerProvider>("Microsoft", LogLevel.Information))
		}
	}
}
