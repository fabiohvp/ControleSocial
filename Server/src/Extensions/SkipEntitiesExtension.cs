using ControleSocial.Domain.Models;

namespace System.Linq
{
    public static class SkipEntitiesExtension
    {
        public static IQueryable<TSource> SkipEntities<TSource>(this IOrderedQueryable<TSource> source, int skip)
            where TSource : class, IEntity
        {
            var entities = source.Select(p => p.Id).Skip(skip);
            return source.Where(o => entities.Contains(o.Id));
        }
    }
}
