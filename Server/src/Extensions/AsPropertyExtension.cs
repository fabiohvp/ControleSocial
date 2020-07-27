namespace System.Linq.Expressions
{
    public static class AsPropertyExtension
    {
        public static Expression<Func<T, string>> AsProperty<T>(this string columnName)
            where T : class
        {
            // x
            var param = Expression.Parameter(typeof(T), "x");

            // x.ColumnName1.ColumnName2
            var property = columnName.Split('.').Aggregate<string, Expression>(param, (c, m) => Expression.Property(c, m));

            // x => x.ColumnName1.ColumnName2
            var lambda = Expression.Lambda<Func<T, string>>(Expression.Convert(property, typeof(string)), param);
            return lambda;
        }
    }
}
