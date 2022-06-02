using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositoris
{
    public class FunctionsViewsAndSprocs
    {
        public static void Execute_fnCompanions(int EpisodeId)
        {
            var companions = DoctorWhoCoreDbContext._context.Companions.Select(c => DoctorWhoCoreDbContext._context.Execute_fnCompanions(EpisodeId)).FirstOrDefault();
            Console.WriteLine(companions);
        }
        public static void Execute_fnEnemies(int EpisodeId)
        {
            var enemies = DoctorWhoCoreDbContext._context.Enemies.Select(e => DoctorWhoCoreDbContext._context.Execute_fnEnemies(EpisodeId)).FirstOrDefault();
            Console.WriteLine(enemies);
        }
        public static void Execute_viewEpisodes()
        {
            var viewResults = DoctorWhoCoreDbContext._context.EpisodeViews.ToList();

            Console.WriteLine(String.Format("{0, 5}|{1, 5}|{2, 5}|{3, 5}",
                   "Doctor_Name", "Author_Name", "Companions", "Enemies"));
            foreach (var result in viewResults)
            {
                Console.WriteLine(String.Format("{0, 5}|{1, 5}|{2, 5}|{3, 5}",
                     result.Doctor_Name, result.Author_Name, result.Companions, result.Enemies));
            }
        }
        public static void Execute_spSummariseEpisodes()
        {
            var companions = DoctorWhoCoreDbContext._context.ThreeMostFrequentlyAppearingCompanions.FromSqlRaw("EXEC spSummariseEpisodeCompanions").ToList();
            foreach (var companion in companions)
            {
                Console.WriteLine(companion._ThreeMostFrequentlyAppearingCompanions);
            }
            var enemies = DoctorWhoCoreDbContext._context.ThreeMostFrequenlyAppearingEnemies.FromSqlRaw("EXEC spSummariseEpisodeEnemies").ToList();
            foreach (var enemy in enemies)
            {
                Console.WriteLine(enemy._ThreeMostFrequentlyAppearingEnemies);
            }
        }

    }
}
