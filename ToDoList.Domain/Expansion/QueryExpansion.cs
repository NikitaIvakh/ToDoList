using System.Linq.Expressions;

namespace ToDoList.Domain.Expansion
{
    public static class QueryExpansion
    {
        public static IQueryable<Type> WhereIf<Type>(this IQueryable<Type> source, bool condition, Expression<Func<Type, bool>> predicate)
        {
            if(condition)
                return source.Where(predicate);

            return source;
        }
    }
}