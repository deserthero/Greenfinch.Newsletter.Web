using Greenfinch.Newsletter.Web.Core.Services.Interfaces.ISpecifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Greenfinch.Newsletter.Web.Core.Services.Specifications
{
    /// <summary>
    ///  Specification pattern used here as simple as write some filters to retrive data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}
