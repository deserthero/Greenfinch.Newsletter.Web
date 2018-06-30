using Greenfinch.Newsletter.Web.Core.Models;
using Greenfinch.Newsletter.Web.Core.Services.Interfaces.IInfrastructures.IRepositories;
using Greenfinch.Newsletter.Web.Infrastructure.EF.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.Infrastructure.EF.Repositories
{
    public class SubscriptionSqlRepository : GenericRepository<Subscriber>, ISubscriptionRepository
    {
        public SubscriptionSqlRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public Subscriber Get(Guid id)
        {
            return _dbContext.Subscribers.FirstOrDefault(s => s.Id == id);
        }

        public Task<Subscriber> GetByIdWithItemsAsync(Guid id)
        {
            return _dbContext.Subscribers.FirstOrDefaultAsync(s => s.Id == id);
        }



    }

}
