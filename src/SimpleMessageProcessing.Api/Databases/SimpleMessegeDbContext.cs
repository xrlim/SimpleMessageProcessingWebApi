using Microsoft.EntityFrameworkCore;
using SimpleMessageProcessing.Library.Models;

namespace SimpleMessageProcessing.Api.Databases {
    public class SimpleMessegeDbContext : DbContext {

        public SimpleMessegeDbContext(DbContextOptions<SimpleMessegeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<SimpleMessage>().HasKey(x => x.Id);
        }

        public DbSet<SimpleMessage> SimpleMessages { get; set; }
    }
}
