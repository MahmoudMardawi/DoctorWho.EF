using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    internal class Doctor
    {
        public Doctor()
        {
            this.Episodes = new List<Episode>();
        }

        //public int DoctorId { get; set; }
        public Doctor(DoctorIdEnum DoctorId, int DoctorNumber, string DoctorName, DateOnly? BirthDate, DateTime? FirstEpisodeDate, DateTime? LastEpisodeDate) : this()
        {
            this.DoctorId = DoctorId;
            this.DoctorNumber = DoctorNumber;
            this.DoctorName = DoctorName;
            this.BirthDate = BirthDate;
            this.FirstEpisodeDate = FirstEpisodeDate;
            this.LastEpisodeDate = LastEpisodeDate;
        }
        public DoctorIdEnum DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DoctorNumber { get; set; }
        public DateOnly? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
        public List<Episode> Episodes { get; }
    }
}
