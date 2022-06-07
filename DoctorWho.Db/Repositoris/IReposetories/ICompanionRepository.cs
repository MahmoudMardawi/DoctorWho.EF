using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Domain.Models;
using DoctorWho.Db.Repositoris;

namespace DoctorWho.Db.Repositoris.IReposetories
{
    public interface ICompanionRepository
    {
        public void Create(string CompanionName, string WhoPlayed);
        public void Update(Companion Companion);
        public void Delete(Companion Companion);
        public Companion GetCompanionById(int CompanionId);


    }
}
