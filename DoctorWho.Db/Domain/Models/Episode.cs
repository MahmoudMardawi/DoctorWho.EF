using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    internal class Episode
    {
        public Episode()
        {
            this.EpisodeCompanion = new List<EpisodeCompanion>();
            this.EpisodeEnemy = new List<EpisodeEnemy>();
        }
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateOnly EpisodeDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Text { get; set; }
        public Companion Companion { get; set; }
        public int CompanionId { get; set; }
        public List<EpisodeCompanion> EpisodeCompanion { get; set; }
        public List<EpisodeEnemy> EpisodeEnemy { get; set; }
    }
}
