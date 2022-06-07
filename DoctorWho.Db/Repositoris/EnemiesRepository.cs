using DoctorWho.Db.Contexts;
using DoctorWho.Db.Domain.Models;
using DoctorWho.Db.Repositoris.IReposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core;

namespace DoctorWho.Db.Repositoris
{
    public class EnemiesRepository : IEnemiesRepository
    {
        public Enemy Create(string EnemyName, string Description)
        {
            if (EnemyName == null) throw new ArgumentNullException("EnemyName must not be null!");
            var NewEnemy = new Enemy(EnemyName, Description);
            DoctorWhoCoreDbContext._context.Enemies.Add(NewEnemy);
            DoctorWhoCoreDbContext._context.SaveChanges();
            return NewEnemy;
        }
        public void Update()
        {
            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public void Delete(Enemy Enemy)
        {
            if (Enemy == null) throw new ArgumentNullException("There is not Enemy in the Enemies table");
            try
            {
                DoctorWhoCoreDbContext._context.Enemies.Remove(Enemy);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Enemy GetEnemyById(int EnemyId)
        {
            var enemy = DoctorWhoCoreDbContext._context.Enemies.Find(EnemyId);
            return enemy != null ? enemy : throw new NullReferenceException("No enemies with the provided Id exist in the database!");
        }
    }
}
