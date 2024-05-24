using Microsoft.EntityFrameworkCore;

namespace TemplateWebApi.Data
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
        }

    }
}
