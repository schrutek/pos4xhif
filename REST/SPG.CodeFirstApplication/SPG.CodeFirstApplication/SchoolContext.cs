using Microsoft.EntityFrameworkCore;
using SPG.CodeFirstApplication.Configurations;
using SPG.CodeFirstApplication.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPG.CodeFirstApplication
{
    public class SchoolContext : DbContext
    {
        public DbSet<Pupil> Pupils { get; set; }

        //public DbSet<SchoolClass> SchoolClasses { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PupilConfiguration());
            //modelBuilder.ApplyConfiguration(new SchoolClassConfiguration());
        }
    }
}
