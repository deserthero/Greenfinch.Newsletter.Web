using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.ISpecifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories
{
    /// <summary>
    /// Generic Async Repository Pattern Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetSingleBySpecAsync(ISpecification<T> spec);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
