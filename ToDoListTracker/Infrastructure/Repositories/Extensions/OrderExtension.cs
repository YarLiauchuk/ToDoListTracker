using System.Linq.Expressions;
using ToDoListTracker.Domain.Enums;
using ToDoListTracker.Domain.Models;

namespace ToDoListTracker.Infrastructure.Repositories.Extensions;

public static class OrderExtension
{
	public static IOrderedQueryable<T> OrderByExpressions<T>(
		this IQueryable<T> query,
		IList<SortExpression> sortExpressions)
		where T : class
	{
		if (sortExpressions == null || !sortExpressions.Any())
			return (IOrderedQueryable<T>)query;

		var isFirst = true;
		IOrderedQueryable<T> orderedQuery = null;

		foreach (var sortExpression in sortExpressions)
		{
			var parameter = Expression.Parameter(typeof(T), "p");
			Expression property = parameter;

			foreach (var prop in sortExpression.PropertyName.Split('.'))
			{
				property = Expression.Property(property, prop);
			}

			var lambda = Expression.Lambda(property, parameter);

			string methodName;
			if (isFirst)
			{
				methodName = sortExpression.Direction == SortDirection.Desc ? "OrderByDescending" : "OrderBy";
				isFirst = false;
			}
			else
			{
				methodName = sortExpression.Direction == SortDirection.Desc ? "ThenByDescending" : "ThenBy";
			}

			orderedQuery = (IOrderedQueryable<T>)typeof(Queryable).GetMethods()
				.Single(
					method => method.Name == methodName
					          && method.IsGenericMethodDefinition
					          && method.GetGenericArguments().Length == 2
					          && method.GetParameters().Length == 2)
				.MakeGenericMethod(typeof(T), property.Type)
				.Invoke(null, new object[] { orderedQuery ?? query, lambda });
		}

		return orderedQuery;
	}
}