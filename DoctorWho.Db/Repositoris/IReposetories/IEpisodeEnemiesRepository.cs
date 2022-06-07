using DoctorWho.Db.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoctorWho.Db.Repositoris.IReposetories
{
    public interface IEpisodeEnemiesRepository
    {
        public void AddEnemyToEpisode(Enemy Enemy, int EpisodeId);

    }
}
