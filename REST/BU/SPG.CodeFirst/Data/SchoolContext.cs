using Data.Configurations;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<SchoolClass> SchoolClasses { get; set; }

        public DbSet<Pupil> Pupils { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchoolClassConfiguration());
            modelBuilder.ApplyConfiguration(new PupilConfiguration());
        }
    }
}
