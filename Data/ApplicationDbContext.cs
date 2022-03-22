using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using rater_api.Models;

namespace rater_api.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=app.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<SchoolProgram>().HasData(
                new SchoolProgram {
                    SchoolProgramId = 1,
                    ProgramName = "FSWD",
                    ProgramDesc = "This is FSWD"
                }
            );
            modelBuilder.Entity<ProgramRate>().HasData(
                new ProgramRate {
                    ProgramRateId = 1,
                    ProgramReview = "FSWD sucks",
                    RateNumber = 1,
                    Created_At = new DateTime(),
                    SchoolProgramId = 1
                }
            );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<rater_api.Models.SchoolProgram> SchoolProgram { get; set; }

        public DbSet<rater_api.Models.ProgramRate> ProgramRate { get; set; }
    }
}
