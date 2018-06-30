using Greenfinch.Newsletter.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
