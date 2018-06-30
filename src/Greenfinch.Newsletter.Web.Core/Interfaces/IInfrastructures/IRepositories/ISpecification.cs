using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
