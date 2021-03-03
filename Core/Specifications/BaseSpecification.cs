using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification <T> : ISpecification <T>
    {
        public BaseSpecification() { }
        public BaseSpecification(Expression < Func <T , bool> > criteria)
        {
            Criteria =criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }
        public List < Expression <Func <T, object> > > Includes { get; } = 
            new List < Expression< Func <T, object> > >();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take  { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnable { get; private set; } 

        protected void AddInclude(Expression < Func<T , object> > includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrederBy (Expression < Func<T , object> > OrderByExpression)
        {
            OrderBy =OrderByExpression;
        }
        protected void AddOrederByDescending (Expression < Func<T , object> > OrderByDescExpression)
        {
            OrderByDescending =OrderByDescExpression;
        }

        protected void ApplyPaging(int skip , int take , bool isPagingEnable =true)
        {
            Skip =skip;
            Take =take;
            IsPagingEnable =isPagingEnable;
        }
    }
}