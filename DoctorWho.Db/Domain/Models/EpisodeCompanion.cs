using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    internal class EpisodeCompanion
    {

        public int EpisodeCompanionId { get; set; }
        public int EpisodeId { get; set; }

        [NotMapped]
        public Episode Episode { get; set; }
        public int CompanionId { get; set; }

        [NotMapped]
        public Companion Companion { get; set; }
    }
}
