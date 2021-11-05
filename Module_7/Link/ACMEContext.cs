using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link
{
    public class ACMEContext : DbContext
    {
        public ACMEContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonCompany>()
                .HasKey(pc => new { pc.PersonId, pc.CompanyId });
        }
    }
}
