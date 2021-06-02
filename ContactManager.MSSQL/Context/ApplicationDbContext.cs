using ContactManager.MSSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.MSSQL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Manager> Managers { get; set; }
    }
}
