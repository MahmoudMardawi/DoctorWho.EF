using DoctorWho.Db.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris.IReposetories
{
    public interface IDoctorRepository
    {
        public void Create(int DoctorId, int DoctorNumber, string DoctorName, DateTime? BirthDate, DateTime? FirstEpisodeDate, DateTime? LastEpisodeDate);
        public void Update(Doctor Doctor);
        public void Delete(Doctor Doctor);
        public List<Doctor> GetAllDoctors();


    }
}
