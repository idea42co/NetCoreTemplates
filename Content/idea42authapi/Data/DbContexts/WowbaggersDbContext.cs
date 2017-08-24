using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationBasic.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace WebApplicationBasic.Data.DbContexts
{
    public class WowbaggersDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public WowbaggersDbContext(DbContextOptions<WowbaggersDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {   
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);
        }
    }
}
