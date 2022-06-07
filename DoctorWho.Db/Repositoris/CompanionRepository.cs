﻿using DoctorWho.Db.Contexts;
using DoctorWho.Db.Domain.Models;
using DoctorWho.Db.Repositoris.IReposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris
{
    public class CompanionsRepository : ICompanionRepository
    {
        public void Create(string CompanionName, string WhoPlayed)
        {
            if (CompanionName == null || WhoPlayed == null)
                throw new ArgumentNullException("Cannot create a Companion with a null CompanionName or a null WhoPlayed!");
            DoctorWhoCoreDbContext._context.Companions.Add(new Companion(CompanionName, WhoPlayed));
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public void Update(Companion Companion)
        {
            if (Companion == null) throw new ArgumentNullException("Comppanion table is empty!");

            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public void Delete(Companion Companion)
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
        }
        public Companion GetCompanionById(int CompanionId)
        {
            var companion = DoctorWhoCoreDbContext._context.Companions.Find(CompanionId);
            return companion != null ? companion : throw new NullReferenceException("No companions with this Id in the table!");
        }
    }
}
