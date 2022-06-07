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
    public class EpisodeEnemiesRepository : IEpisodeEnemiesRepository
    {
        public void AddEnemyToEpisode(Enemy Enemy, int EpisodeId) 
        {
            if (Enemy == null) throw new ArgumentNullException("Invalid input! Please provide an enemy information");
            var episode = DoctorWhoCoreDbContext._context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeEnemies.Add(new EpisodeEnemy { EnemyId = Enemy.EnemyId, EpisodeId = EpisodeId });
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            else throw new InvalidOperationException("Wrong provided Id!");
        }
    }
}
