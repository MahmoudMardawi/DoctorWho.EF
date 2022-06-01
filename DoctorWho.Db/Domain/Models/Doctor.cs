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

        public Doctor(int doctorId, int doctorNumber, string doctorName, DateTime? birthDate, DateTime? firstEpisodeDate, DateTime? lastEpisodeDate)
        {
            DoctorId = doctorId;
            DoctorNumber = doctorNumber;
            DoctorName = doctorName;
            BirthDate = birthDate;
            FirstEpisodeDate = firstEpisodeDate;
            LastEpisodeDate = lastEpisodeDate;
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DoctorNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
        public List<Episode> Episodes { get; }
    }
}
