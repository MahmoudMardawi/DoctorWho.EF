using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    internal class EpisodeCompanion
    {
        public int EpisodeCompanionId { get; set; }
        public Companion CompanonId { get; set; }
        public Episode EpisodeId { get; set; }
    }
}
