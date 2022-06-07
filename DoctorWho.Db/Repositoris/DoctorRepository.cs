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
    public class DoctorsRepository : IDoctorRepository
    {
        public void Create(int DoctorId, int DoctorNumber, string DoctorName, DateTime? BirthDate, DateTime? FirstEpisodeDate, DateTime? LastEpisodeDate)
        {
            if (DoctorName == null) throw new ArgumentNullException("Cannot create a Doctor with a null DoctorName!");
            DoctorWhoCoreDbContext._context.Doctors.Add(new Doctor(DoctorId, DoctorNumber, DoctorName, BirthDate, FirstEpisodeDate, LastEpisodeDate));
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public void Update(Doctor Doctor)
        {
            if (Doctor == null) throw new ArgumentNullException("Doctor table is empty!");

            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public void Delete(Doctor Doctor)
        {
            if (Doctor == null) throw new ArgumentNullException("Doctor table is empty!");
            try
            {
                DoctorWhoCoreDbContext._context.Doctors.Remove(Doctor);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Doctor> GetAllDoctors()
        {
            return DoctorWhoCoreDbContext._context.Doctors.ToList();
        }
    }
}
