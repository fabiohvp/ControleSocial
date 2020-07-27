using System;
using System.Linq.Expressions;

namespace Enflow
{
	public interface IProjection<T, U>
	{
		Expression<Func<T, U>> Predicate { get; }
	}
}