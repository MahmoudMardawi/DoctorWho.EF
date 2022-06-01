using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain
{
    public class EpisodeView
    {
        public int? Series_Number { get; set; }
        public int? Episode_Number { get; set; }
        public string Title { get; set; }
        public string Author_Name { get; set; }
        public string Doctor_Name { get; set; }
        public string Companions { get; set; }
        public string Enemies { get; set; }
    }
}
