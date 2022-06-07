using DoctorWho.Db.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoctorWho.Db.Repositoris.IReposetories
{
    public interface IEpisodesRepository
    {
        public Episode Create(int DoctorId, int? SeriesNumber, int? EpisodeNumber, string EpisodeType, string Title, DateTime? EpisodeDate, int AuthorId, string Notes);
        public void Update();
        public void Delete(Episode Episode);


    }
}
