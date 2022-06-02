using DoctorWho.Db.Domain;
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
            //Author Table
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).HasMaxLength(350);
            modelBuilder.Entity<Author>().HasData(
               new Author { AuthorId = 1, AuthorName = "Allen Cooper" },
               new Author { AuthorId = 2, AuthorName = "Edward Norton" },
               new Author { AuthorId = 3, AuthorName = "Martin Jobs" },
               new Author { AuthorId = 4, AuthorName = "Green" },
               new Author { AuthorId = 5, AuthorName = "Fredrick" });

            //Companion Table
            modelBuilder.Entity<Companion>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).HasMaxLength(350);
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).HasMaxLength(350);
            modelBuilder.Entity<Companion>().HasData(
                new Companion { CompanionId = 1, CompanionName = "Medhat", WhoPlayed = "Foster" },
                new Companion { CompanionId = 2, CompanionName = "Ameen", WhoPlayed = "Skirtel" },
                new Companion { CompanionId = 3, CompanionName = "Mahdi", WhoPlayed = "Lauren" },
                new Companion { CompanionId = 4, CompanionName = "Elina", WhoPlayed = "Austin" },
                new Companion { CompanionId = 5, CompanionName = "Karim", WhoPlayed = "Edward" });

            //Doctor Table

            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).HasMaxLength(350);
            modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, DoctorNumber = 123, DoctorName = "Jack Rocheld", BirthDate = new DateTime(1954, 03, 25), FirstEpisodeDate = new DateTime(1994, 12, 21), LastEpisodeDate = new DateTime(1995, 02, 01) },
                new Doctor { DoctorId = 2, DoctorNumber = 234, DoctorName = "Alesandro", BirthDate = new DateTime(1960, 11, 17), FirstEpisodeDate = new DateTime(1990, 12, 22), LastEpisodeDate = new DateTime(1991, 07, 22) },
                new Doctor { DoctorId = 3, DoctorNumber = 345, DoctorName = "Gabriel", BirthDate = new DateTime(1967, 06, 21), FirstEpisodeDate = new DateTime(2000, 05, 09), LastEpisodeDate = new DateTime(2001, 10, 11) },
                new Doctor { DoctorId = 4, DoctorNumber = 456, DoctorName = "Steven", BirthDate = new DateTime(1970, 08, 28), FirstEpisodeDate = new DateTime(2002, 07, 30), LastEpisodeDate = new DateTime(2003, 12, 12) },
                new Doctor { DoctorId = 5, DoctorNumber = 567, DoctorName = "Frank", BirthDate = new DateTime(1965, 12, 13), FirstEpisodeDate = new DateTime(1993, 09, 14), LastEpisodeDate = new DateTime(1994, 01, 04) });

            //Enemy Table
            modelBuilder.Entity<Enemy>().HasKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).IsRequired();
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).HasMaxLength(350);
            modelBuilder.Entity<Enemy>().Property(e => e.Description).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Enemy>().HasData(
                new Enemy { EnemyId = 1, EnemyName = "Alonso", },
                new Enemy { EnemyId = 2, EnemyName = "Kane", Description = "Enemy 2" },
                new Enemy { EnemyId = 3, EnemyName = "Larvel", Description = "Dom enemy" },
                new Enemy { EnemyId = 4, EnemyName = "Leon" },
                new Enemy { EnemyId = 5, EnemyName = "David" }
                );

            //Episode Table
            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);
            modelBuilder.Entity<Episode>().Property(e => e.SeriesNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).HasMaxLength(50);
            modelBuilder.Entity<Episode>().Property(e => e.Title).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasDefaultValueSql("NULL");

            modelBuilder.Entity<Episode>()
               .HasOne(e => e.Doctor)
               .WithMany(d => d.Episodes)
               .HasForeignKey(e => e.DoctorId);
            modelBuilder.Entity<Episode>()
               .HasOne(e => e.Author)
               .WithMany(a => a.Episodes)
               .HasForeignKey(e => e.AuthorId);
            modelBuilder.Entity<Episode>().HasData(
                new Episode { EpisodeId =1 , SeriesNumber = 123, EpisodeNumber = 1, EpisodeType = "Semi-Pro", Title = "Red Rose",
                    EpisodeDate = new DateTime(1995, 02, 01), AuthorId = 1, DoctorId = 1 },
                new Episode { EpisodeId =2 , SeriesNumber = 234, EpisodeNumber = 2, EpisodeType = "Professional", Title = "White Knight",
                    EpisodeDate = new DateTime(1991, 07, 22), AuthorId = 2, DoctorId = 2 },
                new Episode
                {
                    EpisodeId = 3,
                    SeriesNumber = 345,
                    EpisodeNumber = 3,
                    EpisodeType = "World Class",
                    Title = "Red Sky",
                    EpisodeDate = new DateTime(2001, 10, 11),
                    AuthorId = 3,
                    DoctorId = 3
                },
                new Episode
                {
                    EpisodeId = 4,
                    SeriesNumber = 456,
                    EpisodeNumber = 4,
                    EpisodeType = "Legendary",
                    Title = "Black Burl",
                    EpisodeDate = new DateTime(2002, 07, 30),
                    AuthorId = 4,
                    DoctorId = 5
                },
                new Episode
                {
                    EpisodeId = 5,
                    SeriesNumber = 567,
                    EpisodeNumber = 5,
                    EpisodeType = "World-Class",
                    Title = "In hell",
                    EpisodeDate = new DateTime(1994, 01, 04),
                    AuthorId = 5,
                    DoctorId = 5
                });

            //EpisodeCompanion Table
            modelBuilder.Entity<EpisodeCompanion>().HasKey(ec => ec.EpisodeCompanionId);
            modelBuilder.Entity<EpisodeCompanion>()
                        .HasOne(ec => ec.Companion)
                        .WithMany(c => c.EpisodeCompanions)
                        .HasForeignKey(ec => ec.CompanionId);
            modelBuilder.Entity<EpisodeCompanion>()
                        .HasOne(ce => ce.Episode)
                        .WithMany(e => e.EpisodeCompanions)
                        .HasForeignKey(ce => ce.EpisodeId);
            //modelBuilder.Entity<EpisodeCompanion>().HasData(
            //   new EpisodeCompanion { EpisodeCompanionId = 1, EpisodeId = 2, CompanionId = 3 },
            //   new EpisodeCompanion { EpisodeCompanionId = 2, EpisodeId = 1, CompanionId = 2 },
            //   new EpisodeCompanion { EpisodeCompanionId = 3, EpisodeId = 3, CompanionId = 2 },
            //   new EpisodeCompanion { EpisodeCompanionId = 4, EpisodeId = 1, CompanionId = 4 },
            //   new EpisodeCompanion { EpisodeCompanionId = 5, EpisodeId = 5, CompanionId = 5 }
            //   );

            //EpisodeEnemy Table
            modelBuilder.Entity<EpisodeEnemy>().HasKey(ee => ee.EpisodeEnemyId);
            modelBuilder.Entity<EpisodeEnemy>()
                        .HasOne(ee => ee.Enemy)
                        .WithMany(e => e.EpisodeEnemies)
                        .HasForeignKey(ee => ee.EnemyId);
            modelBuilder.Entity<EpisodeEnemy>().HasData(
                new EpisodeEnemy { EpisodeEnemyId = 1, EpisodeId = 2, EnemyId = 4 },
                new EpisodeEnemy { EpisodeEnemyId = 2, EpisodeId = 1, EnemyId = 3 },
                new EpisodeEnemy { EpisodeEnemyId = 3, EpisodeId = 3, EnemyId = 4 },
                new EpisodeEnemy { EpisodeEnemyId = 4, EpisodeId = 2, EnemyId = 5 },
                new EpisodeEnemy { EpisodeEnemyId = 5, EpisodeId = 4, EnemyId = 1 }
                );

             modelBuilder.Entity<EpisodeView>().HasNoKey().ToView("viewEpisodes");
            base.OnModelCreating(modelBuilder);


            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}
        }
    }
}
