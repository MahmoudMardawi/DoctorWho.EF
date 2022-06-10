using DoctorWho.Db.Contexts;
using DoctorWho.Db.Domain.Models;
using DoctorWho.Db.Repositoris.IReposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris
{
    public class EnemiesRepository<T> : IGenericRepository<Enemy>
    {
        public Enemy Create(Enemy enemy)
        {
            if (enemy.EnemyName == null) throw new ArgumentNullException("EnemyName must not be null!");
            var NewEnemy = new Enemy
            {
               EnemyName = enemy.EnemyName,
                Description = enemy.Description,
            };
            DoctorWhoCoreDbContext._context.Enemies.Add(NewEnemy);
            DoctorWhoCoreDbContext._context.SaveChanges();
            return NewEnemy;
        }
        public Enemy Update(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException("Enemy table is empty!");
            DoctorWhoCoreDbContext._context.SaveChanges(); 
            return enemy;
        }
        public Enemy Delete(Enemy Enemy)
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
            return Enemy;
        }
        public Enemy GetRecordyById(Enemy TId)
        {
            var enemy = DoctorWhoCoreDbContext._context.Enemies.Find(TId.EnemyId);
            if (enemy == null)
            {
                throw new NullReferenceException("No enemies with the provided Id exist in the database!");
            }
            else
            return enemy;  
        }
        public List<Enemy> GetAllRecords()
        {
            return DoctorWhoCoreDbContext._context.Enemies.ToList();
        }

    }
}
