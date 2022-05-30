using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    internal class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DoctorNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly FirstEpisodeDate { get; set; }
        public DateOnly LastEpisodeDate { get; set; }
    }
}
