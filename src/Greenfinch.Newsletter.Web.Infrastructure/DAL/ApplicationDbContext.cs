using Greenfinch.Newsletter.Web.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Greenfinch.Newsletter.Web.Infrastructure.EF.DAL
{
    /// <summary>
    /// EF DbContext (Our Data Layer Unit Of Work accessor)
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        /// <summary>
        /// Subscribers DbSet
        /// </summary>
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
