using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
