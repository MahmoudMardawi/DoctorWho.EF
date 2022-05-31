using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    internal class Enemy
    {
        public Enemy()
        {
            this.EpisodeEnemy = EpisodeEnemy;
        }
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public List<EpisodeEnemy> EpisodeEnemy { get; set; }
    }
}
