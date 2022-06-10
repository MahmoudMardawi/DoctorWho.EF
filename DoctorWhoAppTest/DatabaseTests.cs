using Microsoft.EntityFrameworkCore;
using DoctorWho.Db.Contexts;
using DoctorWho.Db.Domain.Models;

namespace DoctorWhoAppTest
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertAuthorIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<DoctorWhoCoreDbContext>();
            builder.UseSqlServer(@"Data Source=SPECTRUM\SQLEXPRESS;Initial Catalog=DoctorWhoCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            using (var context = new DoctorWhoCoreDbContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var author = new Author { AuthorName ="b" };
                context.Authors.Add(author);
                context.SaveChanges();
                Assert.AreNotEqual(0, author.AuthorId);
            }
        }

        [TestMethod]
        public void CanInsertDoctorIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<DoctorWhoCoreDbContext>();
            builder.UseSqlServer(@"Data Source=SPECTRUM\SQLEXPRESS;Initial Catalog=DoctorWhoCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            using (var context = new DoctorWhoCoreDbContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var doctor = new Doctor { DoctorName="b" };
                context.Doctors.Add(doctor);
                context.SaveChanges();

                Assert.AreNotEqual(0, doctor.DoctorId);
            }
        }
        [TestMethod]

        public void CanInsertCompanionIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<DoctorWhoCoreDbContext>();
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DoctorWhoCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            using (var context = new DoctorWhoCoreDbContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var companion = new Companion { CompanionName = "b" , WhoPlayed="s"};
                context.Companions.Add(companion);
                context.SaveChanges();

                Assert.AreNotEqual(0, companion.CompanionId);
            }
            
        }
    }
}