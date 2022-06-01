using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Db.Domain.Models
{
    public class EpisodeEnemy
    {
        public int EpisodeEnemyId { get; set; }
        public Episode Episode { get; set; }
        public int EpisodeId { get; set; }
        public Enemy Enemy { get; set; }
        public int EnemyId { get; set; }

    }
}
