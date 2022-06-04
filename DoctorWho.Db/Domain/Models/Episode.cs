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

        public Episode(int DoctorId, int? SeriesNumber, int? EpisodeNumber, string EpisodeType,
            string Title, DateTime? EpisodeDate, int AuthorId, string Notes) : this()
        {
            this.DoctorId = DoctorId;
            this.SeriesNumber = (int)SeriesNumber;
            this.EpisodeNumber = (int)EpisodeNumber;
            this.EpisodeType = EpisodeType;
            this.Title = Title;
            this.EpisodeDate = (DateTime)EpisodeDate;
            this.AuthorId = AuthorId;
            this.DoctorId = DoctorId;
            this.Notes = Notes;
        }

        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public string? Notes { get; set; }
        public DateTime EpisodeDate { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public List<EpisodeCompanion> EpisodeCompanions { get; set; }
        public List<EpisodeEnemy> EpisodeEnemies { get; set; }
        public int? SeriesNumber1 { get; }
        public int? EpisodeNumber1 { get; }
        public DateTime? EpisodeDate1 { get; }
    }
}
