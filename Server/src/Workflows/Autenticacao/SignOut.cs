using Microsoft.AspNetCore.Http;
using WorkflowApi.Core.Workflows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace ControleSocial.Workflows.Autenticacao
{
	public class SignOut : Workflow
	{
		public override object Execute(object entryData)
		{
			var httpContextAccessor = Settings.ServiceProvider.GetService<IHttpContextAccessor>();
			Task.WaitAll(httpContextAccessor.HttpContext.SignOutAsync());
			return true;
		}
	}
}
