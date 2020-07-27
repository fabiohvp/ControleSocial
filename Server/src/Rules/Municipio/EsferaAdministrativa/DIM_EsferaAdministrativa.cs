using Enflow;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ControleSocial.Rules.Municipio.EsferaAdministrativa
{
	public class DIM_EsferaAdministrativa : StateRule<ControleSocial.Domain.Models.DWControleSocial.DIM_EsferaAdministrativa>
	{
		private static string[] Ignore = new string[] { "000", "500", "501" };

		public override Expression<Func<ControleSocial.Domain.Models.DWControleSocial.DIM_EsferaAdministrativa, bool>> Predicate
		{
			get
			{
				return o => !Ignore.Contains(o.Codigo);
			}
		}
	}
}
