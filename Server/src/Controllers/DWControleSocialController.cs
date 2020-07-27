using ControleSocial.Domain.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using ControleSocial.WebSockets;
using WorkflowApi.Core.Models;
using WorkflowApi.Core.Reflection;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DWControleSocialController : ControllerBase
	{
		private static TypeCreator TypeCreator = new TypeCreator(nameof(DWControleSocialController));

		private static DWControleSocialContext DbContextFactory()
		{
			return Settings.ServiceProvider.GetService<DWControleSocialContext>();
		}

		private static TypeCreator TypeCreatorFactory()
		{
			return TypeCreator;
		}

		private static IWorkflow WorkflowFactory(string name, object[] args, Type dataType)
		{
			var workflowType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(o => o.FullName.Replace("`1", string.Empty).EndsWith(name))
					?? Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(o => o.FullName.Replace("`1", string.Empty).EndsWith(name));

			if (workflowType.ContainsGenericParameters)
			{
				workflowType = workflowType
						.MakeGenericType(dataType.GetGenericArguments());
			}

			if (args == default)
			{
				return (IWorkflow)ActivatorUtilities.CreateInstance(Settings.ServiceProvider, workflowType);
			}
			return (IWorkflow)ActivatorUtilities.CreateInstance(Settings.ServiceProvider, workflowType, args);
		}

		public object Post([FromBody] Request[] requests)
		{
			return PostInternal(DbContextFactory, requests);
		}

		[DisableRequestSizeLimit]
		//[RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
		[RequestFormLimits(ValueLengthLimit = 2 * 1024 * 1024, MultipartBodyLengthLimit = int.MaxValue)]
		[Route("[Action]")]
		//[Authorize(Roles = "Admin")]
		public object Upload([FromForm] Request request)
		{
			if (Request.Form.Files.Any())
			{
				if (request.Args == default)
				{
					request.Args = new object[] { };
				}

				request.Args = request.Args.Concat(new object[] { Request.Form.Files }).ToArray();
			}

			var requests = new[] { request };
			return PostInternal(DbContextFactory, requests);
		}

		[HttpPost]
		[Route("[Action]")]
		public object Authenticate([FromBody] Request request)
		{
			var requests = new[] { request };
			return PostInternal(() => Settings.ServiceProvider.GetService<ControleSocialContext>(), requests);
		}

		private object PostInternal(Func<DbContext> dbContextFactory, Request[] requests)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var jsonQL = new WorkflowApi.Core.Processor(TypeCreatorFactory, dbContextFactory, WorkflowFactory);

			if (Request.Headers.ContainsKey("socket-guid"))
			{
				var socketGuid = Request.Headers["socket-guid"];

				if (WebSocketWorkflowHandler.Observers.ContainsKey(socketGuid))
				{
					jsonQL.Subscribe(WebSocketWorkflowHandler.Observers[socketGuid]);
				}
			}

			jsonQL.ProcessRequests(requests, Request.Headers);
			stopwatch.Stop();
			Console.WriteLine($"[{DateTime.Now}][{GetType().Name.Replace("Controller", "")}][{stopwatch.Elapsed}] {string.Join(", ", requests.Select(o => o.Id).Where(o => !string.IsNullOrEmpty(o)))}");
			return jsonQL.Values;
		}
	}
}