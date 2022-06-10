using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using DoctorWho.Db.Repositoris.IReposetories;

namespace DoctorWho.Db.Repositoris
{
    public class FunctionsViewsAndSprocs : IFunctionsViewsAndSprocs
    {
        public void Execute_fnCompanions(int EpisodeId)
        {
            var companions = DoctorWhoCoreDbContext._context.Companions.Select(c => DoctorWhoCoreDbContext._context.Execute_fnCompanions(EpisodeId)).FirstOrDefault();
            Console.WriteLine(companions);
        }
        public void Execute_fnEnemies(int EpisodeId)
        {
            var enemies = DoctorWhoCoreDbContext._context.Enemies.Select(e => DoctorWhoCoreDbContext._context.Execute_fnEnemies(EpisodeId)).FirstOrDefault();
            Console.WriteLine(enemies);
        }
        public List<Domain.EpisodeView> Execute_viewEpisodes()
        {
            var viewResults = DoctorWhoCoreDbContext._context.EpisodeViews.ToList();
            foreach (var result in viewResults)
            {
                string s = String.Format("{0, 5}|{1, 5}|{2, 5}|{3, 5}",
                     result.Doctor_Name, result.Author_Name, result.Companions, result.Enemies);
            }
            return viewResults;
        }
        public void Execute_spSummariseEpisodes()
        {
            var CompanionsEnemies = DoctorWhoCoreDbContext._context.ThreeMostFrequentlyAppearingCompanions.FromSqlRaw("EXEC spSummariseEpisodes").ToList();
             
        }

    }
}
