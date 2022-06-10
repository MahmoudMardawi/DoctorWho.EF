using DoctorWho.Db.Domain.Models;
using DoctorWho.Db.Repositoris;
using DoctorWho.Db.Repositoris.IReposetories;
using Moq;


namespace DoctorWhoAppTest
{
    [TestClass]

    public class EnemiesRepositoriesTests
    {

        private readonly Mock<IGenericRepository<Enemy>> IenemiesRepository;
        private readonly EnemiesRepository<Enemy> enemiesRepository;
        public EnemiesRepositoriesTests()
        {
            enemiesRepository = new EnemiesRepository<Enemy>();
            IenemiesRepository = new Mock<IGenericRepository<Enemy>>();
        }
 
        [TestMethod]
        public void ShouldAddEnemyToDb()
        {
            var NewEnemy = new Enemy
            {

                EnemyName = "Alonso",
                Description = null
            };
            IenemiesRepository.Setup(e => e.Create(NewEnemy)).Returns(new Enemy(NewEnemy));
            var result = enemiesRepository.Create(NewEnemy);
            Assert.AreEqual(NewEnemy.EnemyName, result.EnemyName);

        }

        [TestMethod]
        public void ShouldGetEnemyById()
        {
            var NewEnemy = new Enemy
            {
                EnemyId = 7,
                EnemyName = "Alonso",
                Description = null
            };

            IenemiesRepository.Setup(i => i.GetRecordyById(NewEnemy)).Returns(NewEnemy);
            var result = enemiesRepository.GetRecordyById(NewEnemy);
            Assert.AreEqual(NewEnemy.EnemyName, result.EnemyName);

        }


    }
}
