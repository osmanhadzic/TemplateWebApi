using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TemplateWebApi.Data.Entities;

namespace TemplateWebApi.Data
{
    public class TemplateDbContext : IdentityDbContext<User>
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasKey(x => x.Id);
            
            builder.HasDefaultSchema("identity");
        }

    }
}
