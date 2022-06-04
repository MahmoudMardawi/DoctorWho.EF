using DoctorWho.Db.Contexts;
using DoctorWho.Db.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris
{
    public class EnemiesRepository
    {
        public static void Create(string EnemyName, string Description)
        {
            if (EnemyName == null) throw new ArgumentNullException("EnemyName must not be null!");
            DoctorWhoCoreDbContext._context.Enemies.Add(new Enemy(EnemyName, Description));
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Update()
        {
            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Delete(Enemy Enemy)
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
        public static Enemy GetEnemyById(int EnemyId)
        {
            var enemy = DoctorWhoCoreDbContext._context.Enemies.Find(EnemyId);
            return enemy != null ? enemy : throw new NullReferenceException("No enemies with the provided Id exist in the database!");
        }
    }
}
