﻿using DoctorWho.Db.Domain;
using DoctorWho.Db.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DoctorWho.Db.Contexts
{
    public class DoctorWhoCoreDbContext : Microsoft.EntityFrameworkCore.DbContext
    {


        public static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public Microsoft.EntityFrameworkCore.DbSet<Author> Authors { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Companion> Companions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Doctor> Doctors { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Enemy> Enemies { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Episode> Episodes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<EpisodeView> EpisodeViews { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.
     UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DoctorWhoCore;
Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).HasMaxLength(350);
            modelBuilder.Entity<Doctor>().HasData(
            new Doctor {DoctorId=1,  DoctorNumber = 123, DoctorName = "Jack Rocheld", BirthDate = new DateTime(1954, 03, 25), FirstEpisodeDate = new DateTime(1994, 12, 21), LastEpisodeDate = new DateTime(1995, 02, 01) },
                new Doctor { DoctorId = 2, DoctorNumber = 234, DoctorName = "Alesandro", BirthDate = new DateTime(1960, 11, 17), FirstEpisodeDate = new DateTime(1990, 12, 22), LastEpisodeDate = new DateTime(1991, 07, 22) },
                new Doctor { DoctorId = 3, DoctorNumber = 345, DoctorName = "Gabriel", BirthDate = new DateTime(1967, 06, 21), FirstEpisodeDate = new DateTime(2000, 05, 09), LastEpisodeDate = new DateTime(2001, 10, 11) },
                new Doctor { DoctorId = 4, DoctorNumber = 456, DoctorName = "Steven", BirthDate = new DateTime(1970, 08, 28), FirstEpisodeDate = new DateTime(2002, 07, 30), LastEpisodeDate = new DateTime(2003, 12, 12) },
                new Doctor { DoctorId = 5, DoctorNumber = 567, DoctorName = "Frank", BirthDate = new DateTime(1965, 12, 13), FirstEpisodeDate = new DateTime(1993, 09, 14), LastEpisodeDate = new DateTime(1994, 01, 04) });


            modelBuilder.Entity<Companion>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).HasMaxLength(350);
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).HasMaxLength(350);
            modelBuilder.Entity<Companion>().HasData({ });


            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).HasMaxLength(350);
            modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasDefaultValueSql("NULL");
           
            modelBuilder.Entity<Enemy>().HasKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).IsRequired();
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).HasMaxLength(350);
            modelBuilder.Entity<Enemy>().Property(e => e.Description).HasDefaultValueSql("NULL");


            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);
            modelBuilder.Entity<Episode>().Property(e => e.SeriesNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).HasMaxLength(50);
            modelBuilder.Entity<Episode>().Property(e => e.Title).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Episode>().Property(e => e.Text).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Episode>()
               .HasOne(e => e.Doctor)
               .WithMany(d => d.Episodes)
               .HasForeignKey(e => e.DoctorId);
            modelBuilder.Entity<Episode>()
               .HasOne(e => e.Author)
               .WithMany(a => a.Episodes)
               .HasForeignKey(e => e.AuthorId);


            modelBuilder.Entity<EpisodeCompanion>().HasKey(ec => ec.EpisodeCompanionId);
            modelBuilder.Entity<EpisodeCompanion>()
                        .HasOne(ec => ec.Companion)
                        .WithMany(c => c.EpisodeCompanions)
                        .HasForeignKey(ec => ec.CompanionId);

            
            modelBuilder.Entity<EpisodeCompanion>()
                        .HasOne(ce => ce.Episode)
                        .WithMany(e => e.EpisodeCompanions)
                        .HasForeignKey(ce => ce.EpisodeId);

            modelBuilder.Entity<EpisodeEnemy>().HasKey(ee => ee.EpisodeEnemyId);
            modelBuilder.Entity<EpisodeEnemy>()
                        .HasOne(ee => ee.Enemy)
                        .WithMany(e => e.EpisodeEnemies)
                        .HasForeignKey(ee => ee.EnemyId);
          

            modelBuilder.Entity<EpisodeView>().HasNoKey().ToView("viewEpisodes");
            base.OnModelCreating(modelBuilder);


            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}
        }
    }
}
