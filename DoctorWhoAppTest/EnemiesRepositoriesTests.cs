using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Contexts;
using DoctorWho.Db.Repositoris;
using DoctorWho.Db.Repositoris.IReposetories;
using FluentAssertions;
using Moq;
using Xunit;


namespace DoctorWhoAppTest
{
    [TestClass]
    public class EnemiesRepositoriesTests
    {

        private readonly Mock<IEnemiesRepository> IenemiesRepository;
        private readonly EnemiesRepository enemiesRepository;
        public EnemiesRepositoriesTests()
        {
            enemiesRepository = new EnemiesRepository();
            IenemiesRepository = new Mock<IEnemiesRepository>();
        }

        [TestMethod]
        public void ShouldAddEnemyToDb()
        {
            IenemiesRepository.Setup(e => e.Create("Alonso", null)).Returns(new DoctorWho.Db.Domain.Models.Enemy("Alonso", null));
            var result = enemiesRepository.Create("Alonso", null);
            Assert.AreEqual("Alonso", result.EnemyName);
            Assert.AreEqual(null, result.Description);

        }

        [TestMethod]
        public void ShouldGetEnemyById()
        {
            IenemiesRepository.Setup(i => i.GetEnemyById(1)).Returns(new DoctorWho.Db.Domain.Models.Enemy("Alonso", null));
            var result = enemiesRepository.GetEnemyById(1);
            //result.Should().Be("Alonso");
            Assert.AreEqual("Alonso", result.EnemyName);

        }


    }
}
