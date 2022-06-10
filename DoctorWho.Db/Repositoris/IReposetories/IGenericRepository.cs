using DoctorWho.Db.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris.IReposetories
{
    public interface IGenericRepository<T> where T : class
    {
        public T Create(T tValue);
        public T Update(T tValue);
        public T Delete(T tValue);
        public List<T> GetAllRecords();
        public T GetRecordyById(T TId);

    }
}
