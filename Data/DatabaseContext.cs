using ContactControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactControl.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {         
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
