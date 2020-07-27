using EntityFrameworkCore.MemoryJoin;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.EntityFrameworkCore
{
    public static class InsertMergeExtension
    {
        public static List<TEntity> InsertMerge<TEntity, TComparer>
        (
            this IEnumerable<TEntity> entities, 
            Func<DbContext> getDbContext, 
            Expression<Func<TEntity, long>> idSelector, 
            Expression<Func<TEntity, TComparer>> comparerSelector, 
            IObserver<AddRangeObserverResult> observer = default, 
            Func<TEntity, object> updateValuesSelector = default, 
            int amount = 500
        )
            where TEntity : class, new()
        {
            var count = entities.Count();
            var savedEntities = new List<TEntity>();
            var lastDbContext = default(DbContext);

            if (observer == default)
            {
                observer = new AddRangeObserver();
            }

            if (count > 0)
            {
                var type = entities.Select(o => o.GetType()).First();
                var comparerSelectorCompiled = comparerSelector.Compile();
                var idSelectorCompiled = idSelector.Compile();
                var expression = (MemberExpression)idSelector.Body;
                var idName = expression.Member.Name;

                for (var i = 0; i < count; i += amount)
                {
                    var dbContext = getDbContext();
                    dbContext.Database.SetCommandTimeout(300); //5 minutos
                    var entitiesToSave = entities.Skip(i).Take(amount);

                    entitiesToSave = entitiesToSave
                       .GroupBy(comparerSelectorCompiled)
                       .Select(o => o.FirstOrDefault())
                       .ToList();

                    var itemsIdentification = entitiesToSave
                        .GroupBy(comparerSelectorCompiled)
                        .Select(o => new { o.Key })
                        .ToList();

                    var itemsIdentificationQueryable = dbContext.FromLocalList(itemsIdentification);

                    var _savedEntities = dbContext
                        .Set<TEntity>()
                        .AsExpandableEFCore()
                        .Join
                        (
                            itemsIdentificationQueryable,
                            o => comparerSelector.Invoke(o),
                            o => o.Key,
                            (l, r) => l
                        )
                        .Where(o => idSelector.Invoke(o) != default)
                        .ToList();

                    savedEntities.AddRange(_savedEntities);

                    var entitiesToInsert = entitiesToSave
                        .LeftJoin
                        (
                            _savedEntities,
                            o => comparerSelectorCompiled.Invoke(o),
                            o => comparerSelectorCompiled.Invoke(o),
                            o => o.Left.SetValue(idName, o.Right == default ? default : idSelectorCompiled.Invoke(o.Right))
                        )
                        .Where(o => idSelectorCompiled.Invoke(o) == default)
                        .ToList();

                    foreach (var entity in entitiesToInsert)
                    {
                        dbContext.Add(entity);
                        savedEntities.Add(entity);
                    }

                    var entitiesToUpdateCount = 0;

                    if (updateValuesSelector != default)
                    {
                        var entitiesToUpdate = entitiesToSave
                            .Join
                            (
                                _savedEntities,
                                o => comparerSelectorCompiled.Invoke(o),
                                o => comparerSelectorCompiled.Invoke(o),
                                (l, r) => new
                                {
                                    Source = l,
                                    Target = r
                                }
                            )
                            .ToList();

                        var entityProperties = typeof(TEntity)
                            .GetProperties();

                        foreach(var entityToUpdate in entitiesToUpdate)
                        {
                            var obj = updateValuesSelector(entityToUpdate.Source);
                            var properties = obj
                                .GetType()
                                .GetProperties();
                            var needsUpdate = false;

                            foreach (var property in properties)
                            {
                                var entityProperty = entityProperties.First(o => o.Name == property.Name);
                                var entityValue = (IComparable)entityProperty.GetValue(entityToUpdate.Target);
                                var value = property.GetValue(obj);

                                if (entityValue?.CompareTo(value) != 0)
                                {
                                    entityToUpdate.Target.SetValue(property.Name, value);
                                    needsUpdate = true;
                                }
                            }

                            if (needsUpdate)
                            {
                                dbContext.Entry(entityToUpdate.Target).State = EntityState.Modified;
                                entitiesToUpdateCount++;
                            }
                        }
                    }

                    dbContext.SaveChanges();

                    if (dbContext != lastDbContext)
                    {
                        dbContext.Dispose();
                    }

                    lastDbContext = dbContext;

                    observer.OnNext(new AddRangeObserverResult
                    {
                        Date = DateTime.Now,
                        Type = type,
                        Start = i,
                        End = i + amount,
                        Inserted = entitiesToInsert.Count(),
                        Total = count,
                        Updated = entitiesToUpdateCount
                    });
                }
            }
            observer.OnCompleted();
            return savedEntities;
        }
    }
}
