using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Domain.Models;
using DoctorWho.Db.Contexts;
using DoctorWho.Db.Repositoris.IReposetories;

namespace DoctorWho.Db.Repositoris
{
    public class EpisodesRepository : IEpisodesRepository
    {
        public Episode Create(int DoctorId, int? SeriesNumber, int? EpisodeNumber, string EpisodeType, string Title, DateTime? EpisodeDate, int AuthorId,  string Notes)
        {
            if (Title == null) throw new ArgumentNullException("Cannot create an Episode with a null Title!");
            var NewEpisode = new Episode(DoctorId, SeriesNumber, EpisodeNumber, EpisodeType, Title, EpisodeDate, AuthorId, Notes);
            DoctorWhoCoreDbContext._context.Episodes.Add(NewEpisode);
            DoctorWhoCoreDbContext._context.SaveChanges();
            return NewEpisode;
        }
        public void Update()
        {
            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
            
        }
        public void Delete(Episode Episode)
        {
            if (Episode == null) throw new ArgumentNullException("Cannot remove a null Episode from the Episodes table");
            try
            {
                DoctorWhoCoreDbContext._context.Episodes.Remove(Episode);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
