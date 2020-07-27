using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace ControleSocial
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
				Host.CreateDefaultBuilder(args)
						.ConfigureAppConfiguration((hostingContext, config) =>
						{
							var environment = hostingContext.HostingEnvironment.EnvironmentName;
							config
										 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
										 .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
							Console.WriteLine($"Running {environment} settings");
						})
						.ConfigureWebHostDefaults(webBuilder =>
						{
							webBuilder.UseStartup<Startup>()
											.UseUrls("http://*:8999");
						});
	}
}
