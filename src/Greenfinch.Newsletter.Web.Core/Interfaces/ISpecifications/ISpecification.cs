using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Greenfinch.Newsletter.Web.Core.Services.Interfaces.ISpecifications
{
    /// <summary>
    /// Specification pattern used here as simple as write some filters to retrive data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
