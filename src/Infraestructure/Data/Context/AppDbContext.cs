using Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Application.Data
{
    /// <summary>
    /// Application context database 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>10/07/2021</date>
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TypeIdentification> TypeIdentifications { get; set; }

        public DbSet<CardFail> CardFails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
