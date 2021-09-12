using Microsoft.EntityFrameworkCore;
using Scoring.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Scoring.CoreServices.Extensions
{
    public static class EntityToolsExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, List<Expression<Func<T, object>>> includes) where T : BaseEntity
        {
            foreach (var include in includes)
            {
                    queryable = queryable.Include(include);
            }


            return queryable;
        }
    }
}
