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
                new SchoolProgram
                {
                    SchoolProgramId = 1,
                    ProgramName = "Full-Stack Web Development",
                    ProgramDesc = "The Full-Stack Web Development Diploma (FSWD) features an interdisciplinary learning environment to prepare you for a career as a web developer.Focusing on emerging web application development tools and technologies,this unique two - year full - time program offers hands - on experience combined with industry projects to equip you for the many opportunities in this fast - growing and high - demand field."
                },

               new SchoolProgram
               {
                   SchoolProgramId = 2,
                   ProgramName = "Computer Information Technology",
                   ProgramDesc = "STUDY COMPUTING & INFORMATION TECHNOLOGY COMPUTER INFORMATION TECHNOLOGYComputer Information Technology",
               },

               new SchoolProgram
               {
                   SchoolProgramId = 3,
                   ProgramName = "Computer Systems Technology",
                   ProgramDesc = "BCIT’s Computer Systems Technology (CST) two-year diploma program combines computer systems theory with hands-on practical experience in software development. You’ll learn software engineering and programming from industry professionals, and gain experience working on real projects, from concept to deployment. In second year, specialty options add depth and further hone your skills."
               },
           
               new SchoolProgram
               {
                   SchoolProgramId = 4,
                   ProgramName = "Digital Design and Development",
                   ProgramDesc = "In the Digital Design and Development diploma program at BCIT, you will build a solid foundation in designing, developing, and creating interactive, dynamic, immersive social and online applications across various digital media platforms.Learn to work within a team to design and develop web and mobile applications, educational products, video, and audio assets for interactive media and business applications."
               }
            );

            modelBuilder.Entity<ProgramRate>().HasData(
                new ProgramRate
                {
                    ProgramRateId = 1,
                    ProgramReview = "The program have you do video story telling, counting cash flow, and think about ethic issues when you don't even have solid understanding on OOP. This is just ridiculous. For those who are looking to enter this program, think twice.",
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
