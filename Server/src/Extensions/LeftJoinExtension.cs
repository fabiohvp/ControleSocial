using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq
{
	public static class LeftJoinExtensions
	{
		public static IQueryable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>
		(
			this IQueryable<TOuter> left,
			IQueryable<TInner> right,
			Expression<Func<TOuter, TKey>> leftKeySelector,
			Expression<Func<TInner, TKey>> rightKeySelector,
			Expression<Func<JoinResult<TOuter, TInner>, TResult>> resultSelector)
		{
			var result = left
				.GroupJoin(right, leftKeySelector, rightKeySelector, (outer1, inners) => new { outer1, inners = inners.DefaultIfEmpty() })
				.SelectMany(row => row.inners, (row, inner1) => new JoinResult<TOuter, TInner> { Left = row.outer1, Right = inner1 })
				.Select(resultSelector);

			return result;
		}

		public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>
		(
			this IEnumerable<TOuter> left,
			IEnumerable<TInner> right,
			Func<TOuter, TKey> leftKeySelector,
			Func<TInner, TKey> rightKeySelector,
			Func<JoinResult<TOuter, TInner>, TResult> resultSelector)
		{
			var result = left
				.GroupJoin(right, leftKeySelector, rightKeySelector, (outer1, inners) => new { outer1, inners = inners.DefaultIfEmpty() })
				.SelectMany(row => row.inners, (row, inner1) => new JoinResult<TOuter, TInner> { Left = row.outer1, Right = inner1 })
				.Select(resultSelector);

			return result;
		}

		public class JoinResult<TOuter, TInner>
		{
			public TOuter Left { get; set; }
			public TInner Right { get; set; }
		}
	}
}
