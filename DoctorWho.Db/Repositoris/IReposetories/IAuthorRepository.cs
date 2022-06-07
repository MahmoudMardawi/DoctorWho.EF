using DoctorWho.Db.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositoris.IReposetories
{
    public interface IAuthorRepository
    {
        public void Create(string AuthorName);
        public void Update(Author Author);
        public void Delete(Author Author);

    }
}
