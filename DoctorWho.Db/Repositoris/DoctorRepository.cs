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
    public class DoctorsRepository <T>: IGenericRepository<Doctor>
    {
        public Doctor Create(Doctor doctor) 
        {
            if (doctor.DoctorName == null) throw new ArgumentNullException("Cannot create a Doctor with a null DoctorName!");
            var NewDoctor = new Doctor
            {
                DoctorId = doctor.DoctorId,
                DoctorNumber = doctor.DoctorNumber,
                DoctorName = doctor.DoctorName,
                BirthDate = doctor.BirthDate,
                FirstEpisodeDate = doctor.FirstEpisodeDate,
                LastEpisodeDate = doctor.LastEpisodeDate
            };
            DoctorWhoCoreDbContext._context.Doctors.Add(NewDoctor);
            DoctorWhoCoreDbContext._context.SaveChanges();
            return NewDoctor;
        }
        public Doctor Update(Doctor Doctor)
        {
            if (Doctor == null) throw new ArgumentNullException("Doctor table is empty!");

            DoctorWhoCoreDbContext._context.SaveChanges();
            return Doctor;
        }
        public Doctor Delete(Doctor Doctor)
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
            return Doctor;
        }
        public List<Doctor> GetAllRecords()
        {
            return DoctorWhoCoreDbContext._context.Doctors.ToList();
        }
        public Doctor GetRecordyById(Doctor TId)
        {
            var _doctor = DoctorWhoCoreDbContext._context.Doctors.Find(TId.DoctorId);
            return _doctor != null ? _doctor : throw new NullReferenceException("No companions with this Id in the table!");
        }

    }
}
