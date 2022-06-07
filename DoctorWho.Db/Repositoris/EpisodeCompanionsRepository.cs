using DoctorWho.Db.Contexts;
using DoctorWho.Db.Domain.Models;
using DoctorWho.Db.Repositoris.IReposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris
{
    public class EpisodeCompanionsRepository : IEpisodeCompanionsRepository
    {
        public void AddCompanionToEpisode(Companion Companion, int EpisodeId)
        {
            if (Companion == null) throw new ArgumentNullException("Invalid input! Please provide a companion infomation");
            var episode = DoctorWhoCoreDbContext._context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { CompanionId = Companion.CompanionId, EpisodeId = EpisodeId });
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            else throw new InvalidOperationException("Invalid provided Id!");
        }
    }
}
