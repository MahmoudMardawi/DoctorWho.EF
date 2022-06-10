﻿// <auto-generated />
using System;
using DoctorWho.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    [DbContext(typeof(DoctorWhoCoreDbContext))]
    [Migration("20220610140115_CommitMigration")]
    partial class CommitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoctorWho.Db.Domain.EpisodeView", b =>
                {
                    b.Property<string>("Author_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Companions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enemies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Episode_Number")
                        .HasColumnType("int");

                    b.Property<int?>("Series_Number")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToView("viewEpisodes");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AuthorName = "Allen Cooper"
                        },
                        new
                        {
                            AuthorId = 2,
                            AuthorName = "Edward Norton"
                        },
                        new
                        {
                            AuthorId = 3,
                            AuthorName = "Martin Jobs"
                        },
                        new
                        {
                            AuthorId = 4,
                            AuthorName = "Green"
                        },
                        new
                        {
                            AuthorId = 5,
                            AuthorName = "Fredrick"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Companion", b =>
                {
                    b.Property<int>("CompanionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanionId"), 1L, 1);

                    b.Property<string>("CompanionName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("WhoPlayed")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("CompanionId");

                    b.ToTable("Companions");

                    b.HasData(
                        new
                        {
                            CompanionId = 1,
                            CompanionName = "Medhat",
                            WhoPlayed = "Foster"
                        },
                        new
                        {
                            CompanionId = 2,
                            CompanionName = "Ameen",
                            WhoPlayed = "Skirtel"
                        },
                        new
                        {
                            CompanionId = 3,
                            CompanionName = "Mahdi",
                            WhoPlayed = "Lauren"
                        },
                        new
                        {
                            CompanionId = 4,
                            CompanionName = "Elina",
                            WhoPlayed = "Austin"
                        },
                        new
                        {
                            CompanionId = 5,
                            CompanionName = "Karim",
                            WhoPlayed = "Edward"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("DoctorNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FirstEpisodeDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("NULL");

                    b.Property<DateTime?>("LastEpisodeDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            BirthDate = new DateTime(1954, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Jack Rocheld",
                            DoctorNumber = 123,
                            FirstEpisodeDate = new DateTime(1994, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(1995, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 2,
                            BirthDate = new DateTime(1960, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Alesandro",
                            DoctorNumber = 234,
                            FirstEpisodeDate = new DateTime(1990, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(1991, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 3,
                            BirthDate = new DateTime(1967, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Gabriel",
                            DoctorNumber = 345,
                            FirstEpisodeDate = new DateTime(2000, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(2001, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 4,
                            BirthDate = new DateTime(1970, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Steven",
                            DoctorNumber = 456,
                            FirstEpisodeDate = new DateTime(2002, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(2003, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 5,
                            BirthDate = new DateTime(1965, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Frank",
                            DoctorNumber = 567,
                            FirstEpisodeDate = new DateTime(1993, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(1994, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Enemy", b =>
                {
                    b.Property<int>("EnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyId"), 1L, 1);

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("EnemyId");

                    b.ToTable("Enemies");

                    b.HasData(
                        new
                        {
                            EnemyId = 1,
                            EnemyName = "Alonso"
                        },
                        new
                        {
                            EnemyId = 2,
                            Description = "Enemy 2",
                            EnemyName = "Kane"
                        },
                        new
                        {
                            EnemyId = 3,
                            Description = "Dom enemy",
                            EnemyName = "Larvel"
                        },
                        new
                        {
                            EnemyId = 4,
                            EnemyName = "Leon"
                        },
                        new
                        {
                            EnemyId = 5,
                            EnemyName = "David"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpisodeId"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EpisodeDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("NULL");

                    b.Property<int>("EpisodeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("0");

                    b.Property<string>("EpisodeType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Notes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("NULL");

                    b.Property<int>("SeriesNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodeId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Episodes");

                    b.HasData(
                        new
                        {
                            EpisodeId = 1,
                            AuthorId = 1,
                            DoctorId = 1,
                            EpisodeDate = new DateTime(1995, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 1,
                            EpisodeType = "Semi-Pro",
                            SeriesNumber = 123,
                            Title = "Red Rose"
                        },
                        new
                        {
                            EpisodeId = 2,
                            AuthorId = 2,
                            DoctorId = 2,
                            EpisodeDate = new DateTime(1991, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 2,
                            EpisodeType = "Professional",
                            SeriesNumber = 234,
                            Title = "White Knight"
                        },
                        new
                        {
                            EpisodeId = 3,
                            AuthorId = 3,
                            DoctorId = 3,
                            EpisodeDate = new DateTime(2001, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 3,
                            EpisodeType = "World Class",
                            SeriesNumber = 345,
                            Title = "Red Sky"
                        },
                        new
                        {
                            EpisodeId = 4,
                            AuthorId = 4,
                            DoctorId = 5,
                            EpisodeDate = new DateTime(2002, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 4,
                            EpisodeType = "Legendary",
                            SeriesNumber = 456,
                            Title = "Black Burl"
                        },
                        new
                        {
                            EpisodeId = 5,
                            AuthorId = 5,
                            DoctorId = 5,
                            EpisodeDate = new DateTime(1994, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 5,
                            EpisodeType = "World-Class",
                            SeriesNumber = 567,
                            Title = "In hell"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.EpisodeCompanion", b =>
                {
                    b.Property<int>("EpisodeCompanionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpisodeCompanionId"), 1L, 1);

                    b.Property<int>("CompanionId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.HasKey("EpisodeCompanionId");

                    b.HasIndex("CompanionId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("EpisodeCompanions");

                    b.HasData(
                        new
                        {
                            EpisodeCompanionId = 1,
                            CompanionId = 3,
                            EpisodeId = 2
                        },
                        new
                        {
                            EpisodeCompanionId = 2,
                            CompanionId = 2,
                            EpisodeId = 1
                        },
                        new
                        {
                            EpisodeCompanionId = 3,
                            CompanionId = 2,
                            EpisodeId = 3
                        },
                        new
                        {
                            EpisodeCompanionId = 4,
                            CompanionId = 4,
                            EpisodeId = 1
                        },
                        new
                        {
                            EpisodeCompanionId = 5,
                            CompanionId = 5,
                            EpisodeId = 5
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.EpisodeEnemy", b =>
                {
                    b.Property<int>("EpisodeEnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpisodeEnemyId"), 1L, 1);

                    b.Property<int>("EnemyId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.HasKey("EpisodeEnemyId");

                    b.HasIndex("EnemyId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("EpisodeEnemies");

                    b.HasData(
                        new
                        {
                            EpisodeEnemyId = 1,
                            EnemyId = 4,
                            EpisodeId = 2
                        },
                        new
                        {
                            EpisodeEnemyId = 2,
                            EnemyId = 3,
                            EpisodeId = 1
                        },
                        new
                        {
                            EpisodeEnemyId = 3,
                            EnemyId = 4,
                            EpisodeId = 3
                        },
                        new
                        {
                            EpisodeEnemyId = 4,
                            EnemyId = 5,
                            EpisodeId = 2
                        },
                        new
                        {
                            EpisodeEnemyId = 5,
                            EnemyId = 1,
                            EpisodeId = 4
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.ThreeMostFrequentlyAppearingCompanions", b =>
                {
                    b.Property<string>("_ThreeMostFrequentlyAppearingCompanions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ThreeMostFrequentlyAppearingCompanions");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.ThreeMostFrequentlyAppearingEnemies", b =>
                {
                    b.Property<string>("_ThreeMostFrequentlyAppearingEnemies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ThreeMostFrequenlyAppearingEnemies");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Episode", b =>
                {
                    b.HasOne("DoctorWho.Db.Domain.Models.Author", "Author")
                        .WithMany("Episodes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.Domain.Models.Doctor", "Doctor")
                        .WithMany("Episodes")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.EpisodeCompanion", b =>
                {
                    b.HasOne("DoctorWho.Db.Domain.Models.Companion", "Companion")
                        .WithMany("EpisodeCompanions")
                        .HasForeignKey("CompanionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.Domain.Models.Episode", "Episode")
                        .WithMany("EpisodeCompanions")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companion");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.EpisodeEnemy", b =>
                {
                    b.HasOne("DoctorWho.Db.Domain.Models.Enemy", "Enemy")
                        .WithMany("EpisodeEnemies")
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.Domain.Models.Episode", "Episode")
                        .WithMany("EpisodeEnemies")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enemy");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Author", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Companion", b =>
                {
                    b.Navigation("EpisodeCompanions");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Doctor", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Enemy", b =>
                {
                    b.Navigation("EpisodeEnemies");
                });

            modelBuilder.Entity("DoctorWho.Db.Domain.Models.Episode", b =>
                {
                    b.Navigation("EpisodeCompanions");

                    b.Navigation("EpisodeEnemies");
                });
#pragma warning restore 612, 618
        }
    }
}
