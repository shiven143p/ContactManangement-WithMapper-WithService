using ContactManangement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManangement.Data
{
    public class DBContext : DbContext
    {
        //protected readonly IConfiguration _configuration;
        //public DBContext(IConfiguration configuration) { 
        //    _configuration = configuration; 
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ContactDb");
        }

        public DbSet<Contact> Contacts { get; set; } = null!;
    }
}
