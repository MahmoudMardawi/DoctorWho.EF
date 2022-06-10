using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris.IReposetories
{
    public interface IFunctionsViewsAndSprocs
    {
        public void Execute_fnCompanions(int EpisodeId);
        public void Execute_fnEnemies(int EpisodeId);
        public List<Domain.EpisodeView> Execute_viewEpisodes();
        public void Execute_spSummariseEpisodes();

    }
}
