using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    public class Episode
    {
        public Episode()
        {
            this.EpisodeCompanions = new List<EpisodeCompanion>();
            this.EpisodeEnemies = new List<EpisodeEnemy>();
        }
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public List<EpisodeCompanion> EpisodeCompanions { get; set; }
        public List<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}
