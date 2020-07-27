using LinqKit;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using WorkflowApi.Core.Workflows;

namespace ControleSocial.Workflows.String
{
	public class Contains<T> : QueryableWorkflow<T>
			where T : class
	{
		public string Column;
		public string[] Args;
		public bool Not;

		public Contains(string column, JArray args, bool not = false)
		{
			Column = column;
			Args = args.ToObject<string[]>();
			Not = not;
		}

		public override IQueryable<T> Execute(IQueryable<T> entryData)
		{
			var selector = Column.AsProperty<T>();

			if (Not)
			{
				Func<string, Expression<Func<T, bool>>> expression = arg => row => !selector.Invoke(row).Contains(arg);
				return entryData
						.Where(expression, Args);
			}
			else
			{
				Func<string, Expression<Func<T, bool>>> expression = arg => row => selector.Invoke(row).Contains(arg);
				return entryData
						.Where(expression, Args);
			}
		}
	}
}
