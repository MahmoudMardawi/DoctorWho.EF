using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    public class Enemy
    {
   
        public Enemy()
        {
            this.EpisodeEnemies = new List<EpisodeEnemy>();
        }

        public Enemy(string EnemyName, string Description) : this()
        {
            this.EnemyName = EnemyName;
            this.Description = Description;
        }

        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string? Description { get; set; } 
        public List<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}
