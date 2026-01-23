using System.Linq.Expressions;

namespace WebPOS.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string sortColumn)
        {
            return source.OrderBy(ToLambda<T>(sortColumn));
        }

        public static IQueryable<T> OrderByDescendingDynamic<T>(this IQueryable<T> source, string sortColumn)
        {
            return source.OrderByDescending(ToLambda<T>(sortColumn));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.Convert(Expression.Property(param, propertyName), typeof(object));
            return Expression.Lambda<Func<T, object>>(body, param);
        }
    }

}
