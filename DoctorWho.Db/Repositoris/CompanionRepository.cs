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
    public class CompanionsRepository<T> : IGenericRepository<Companion>
    {
        public Companion Create(Companion companion)
        {
            if (companion.CompanionName == null || companion.WhoPlayed == null)
                throw new ArgumentNullException("Cannot create a Companion with a null CompanionName or a null WhoPlayed!");
            var NewCompanion = new Companion { CompanionName = companion.CompanionName, WhoPlayed = companion.WhoPlayed };
            DoctorWhoCoreDbContext._context.Companions.Add(NewCompanion);
            DoctorWhoCoreDbContext._context.SaveChanges();
            return NewCompanion;
        }
        public Companion Update(Companion Companion)
        {
            if (Companion == null) throw new ArgumentNullException("Comppanion table is empty!");
             DoctorWhoCoreDbContext._context.SaveChanges();
            return Companion;
        }
        public Companion Delete(Companion Companion)
        {
            if (Companion == null) throw new ArgumentNullException("Comppanion table is empty!");
            try
            {
                DoctorWhoCoreDbContext._context.Companions.Remove(Companion);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Companion;
        }
        public List<Companion> GetAllRecords()
        {
            return DoctorWhoCoreDbContext._context.Companions.ToList();

        }

        public Companion GetRecordyById(Companion TId)
        {
            var companion = DoctorWhoCoreDbContext._context.Companions.Find(TId.CompanionId);
            return companion != null ? companion : throw new NullReferenceException("No companions with this Id in the table!");
        }
    }
}
