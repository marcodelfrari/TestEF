using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace TestEF.Extensions
{
	public static partial class CustomExtensions
	{
		public static IQueryable Query(this DbContext context, string entityName) =>
			context.Query(context.Model.FindEntityType(entityName).ClrType);

		static readonly MethodInfo SetMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set));

		public static IQueryable Query(this DbContext context, Type entityType) =>
			(IQueryable)SetMethod.MakeGenericMethod(entityType).Invoke(context, null);
		 
	}
}