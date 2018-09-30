using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace bookshop.QueryObjects
{
    public static class IQueryObjectExtensions
    {
        public static IQueryable<T> ApplyOrder<T> (this IQueryable<T> query ,  IQueryObject queryObject,  Dictionary<string, Expression<Func<T, object>>> dict){

            if (queryObject.SortBy == null || !dict.ContainsKey(queryObject.SortBy))
                return query;

            if (queryObject.IsSortAsc)
                return query.OrderBy(dict[queryObject.SortBy]);

            return query.OrderByDescending(dict[queryObject.SortBy]);
            
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObject){
                if (queryObject.Page <= 0 )
                    queryObject.Page = 1;

                if (queryObject.PageSize <= 0 )
                    queryObject.PageSize = 10;

            return query.Skip((queryObject.Page - 1) * queryObject.PageSize ).Take(queryObject.PageSize);
        }
    }
}