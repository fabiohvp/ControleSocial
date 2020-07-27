using System.Linq.Expressions;

namespace System.Linq
{
    public static class LikeAnyExtension
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> queryable, Func<string, Expression<Func<T, bool>>> expression, string[] args)
            where T : class
        {
            var parameter = Expression.Parameter(typeof(T));

            return queryable.Where
            (
                Expression.Lambda<Func<T, bool>>
                (
                    args.Select(expression)
                        .Aggregate<Expression<Func<T, bool>>, Expression>
                        (
                            null,
                            (current, predicate) =>
                            {
                                var visitor = new ParameterSubstitutionVisitor(predicate.Parameters[0], parameter);
                                return current != null ? Expression.OrElse(current, visitor.Visit(predicate.Body)) : visitor.Visit(predicate.Body);
                            }
                        ),
                    parameter
                )
            );
        }

        private class ParameterSubstitutionVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _destination;
            private readonly ParameterExpression _source;

            public ParameterSubstitutionVisitor(ParameterExpression source, ParameterExpression destination)
            {
                _source = source;
                _destination = destination;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return ReferenceEquals(node, _source) ? _destination : base.VisitParameter(node);
            }
        }
    }
}
