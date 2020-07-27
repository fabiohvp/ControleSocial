using ControleSocial.Domain.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleSocial.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DatabaseController : ControllerBase
	{
		private DWControleSocialContext DWControleSocialContext;
		private ControleSocialContext ControleSocialContext;

		public DatabaseController(DWControleSocialContext dwControleSocialContext, ControleSocialContext controleSocialContext)
		{
			DWControleSocialContext = dwControleSocialContext;
			ControleSocialContext = controleSocialContext;
		}


		[HttpGet]
		[Route("[Action]")]
		public void Create()
		{
			//ControleSocialContext.Database.EnsureCreated();
			ControleSocialContext.Database.ExecuteSqlCommand("DBCC TRACEOFF (3459, -1)");
			ControleSocialContext.Database.Migrate();
			ControleSocialContext.Database.ExecuteSqlCommand("DBCC TRACEON (3459, -1)");
			ControleSocialContext.Dispose();
			//DWControleSocialContext.Database.EnsureCreated();
			DWControleSocialContext.Database.ExecuteSqlCommand("DBCC TRACEOFF (3459, -1)");
			DWControleSocialContext.Database.Migrate();
			DWControleSocialContext.Database.ExecuteSqlCommand("DBCC TRACEON (3459, -1)");
			DWControleSocialContext.Dispose();
		}
	}
}
