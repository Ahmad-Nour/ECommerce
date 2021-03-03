using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator <TEntity> where TEntity : BaseEntites
    {
        public static IQueryable <TEntity> GetQuery (IQueryable <TEntity> inputQuery , ISpecification <TEntity> spec)
        {
            var query =inputQuery;

            if(spec.Criteria !=null)
            {
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy !=null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if(spec.OrderByDescending !=null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            if(spec.IsPagingEnable)
            {
                query =query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query , (current , include) =>current.Include(include));
            return query;
        }
    }
}