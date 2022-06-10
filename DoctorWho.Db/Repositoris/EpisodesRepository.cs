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
    public class EpisodesRepository<T> : IGenericRepository<Episode>
    {
        public Episode Create(Episode episode)
        {
            if (episode.Title == null) throw new ArgumentNullException("Cannot create an Episode with a null Title!");
            var NewEpisode = new Episode
            {
                DoctorId = episode.DoctorId,
                SeriesNumber = episode.SeriesNumber,
                EpisodeNumber = episode.EpisodeNumber,
                EpisodeType = episode.EpisodeType,
                Title = episode.Title,
                EpisodeDate = episode.EpisodeDate,
                AuthorId = episode.AuthorId,
                Notes = episode.Notes
            };
            DoctorWhoCoreDbContext._context.Episodes.Add(NewEpisode);
            DoctorWhoCoreDbContext._context.SaveChanges();
            return NewEpisode;
        }
        public Episode Update(Episode episode)
        {
            if (episode == null) throw new ArgumentNullException("Enemy table is empty!");
            DoctorWhoCoreDbContext._context.SaveChanges();
            return episode;
        }
        public Episode Delete(Episode Episode)
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
            return Episode;
        }
        public List<Episode> GetAllRecords()
        {
            return DoctorWhoCoreDbContext._context.Episodes.ToList();

        }
        public Episode GetRecordyById(Episode TId)
        {
            var episode = DoctorWhoCoreDbContext._context.Episodes.Find(TId.EpisodeId);
            return episode != null ? episode : throw new NullReferenceException("No companions with this Id in the table!");
        }

    }
}
