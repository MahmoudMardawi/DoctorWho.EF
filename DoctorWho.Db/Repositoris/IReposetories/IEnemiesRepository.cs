using DoctorWho.Db.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris.IReposetories
{
    public interface IEnemiesRepository 
    {
        public Enemy Create(string EnemyName, string Description);
        public void Update();
        public void Delete(Enemy Enemy);
        public Enemy GetEnemyById(int EnemyId);

    }
}
