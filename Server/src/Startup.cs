using ControleSocial.Domain.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using ControleSocial.WebSockets;

namespace ControleSocial
{
	public class Startup
	{
		public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver()
		};

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false,
				RequireExpirationTime = false,
				ValidateLifetime = true
			};

			services
					.AddDbContext<ControleSocialContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ControleSocial")), ServiceLifetime.Transient)
					.AddDbContext<DWControleSocialContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DWControleSocial")), ServiceLifetime.Transient)
					.AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
					.AddSingleton(Configuration)
					.AddSingleton(tokenValidationParameters)
					.AddCors()
					.AddWebSocketService()
					.AddControllers()
					.AddNewtonsoftJson();

			services.AddHealthChecks();

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.SaveToken = true;
				x.TokenValidationParameters = tokenValidationParameters;
			});

			Settings.ServiceProvider = services.BuildServiceProvider();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			app.UseWebSockets();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapWebSocketManager("/socket", serviceProvider.GetService<WebSocketWorkflowHandler>());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHealthChecks("/health");
			});
		}
	}
}