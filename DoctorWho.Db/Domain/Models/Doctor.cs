using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Episodes = new List<Episode>();
        }

        public Doctor(int DoctorId, int DoctorNumber, string DoctorName, DateTime? BirthDate, DateTime? FirstEpisodeDate, DateTime? LastEpisodeDate):this()
        {
            this.DoctorId = DoctorId;
            this.DoctorNumber = DoctorNumber;
            this.DoctorName = DoctorName;
            this.BirthDate = BirthDate;
            this.FirstEpisodeDate = FirstEpisodeDate;
            this.LastEpisodeDate = LastEpisodeDate;
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DoctorNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
        public List<Episode> Episodes { get; }

        public static implicit operator DbSet<object>(Doctor v)
        {
            throw new NotImplementedException();
        }
    }
}
