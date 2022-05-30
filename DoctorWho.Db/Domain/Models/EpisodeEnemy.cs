using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    internal class EpisodeEnemy
    {
        public int EpisodeEnemyId { get; set; }
        public Enemy EnemyId { get; set; }
        public Episode EpisodeId { get; set; }
    }
}
