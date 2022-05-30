using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    internal class Episode
    {
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateOnly EpisodeDate { get; set; }
        public Author AuthorId { get; set; }
        public Doctor DoctorId { get; set; }
        public string Text { get; set; }

    }
}
