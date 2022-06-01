using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Models
{
    public class Author
    {
        public Author()
        {
            this.Episodes = new List<Episode>();
        }
        public Author(string AuthorName) : this()
        {
            this.AuthorName = AuthorName;
        }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Episode> Episodes { get; }

    }
}
