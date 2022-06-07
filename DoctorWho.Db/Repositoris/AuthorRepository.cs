using DoctorWho.Db.Domain.Models;
using DoctorWho.Db.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Repositoris.IReposetories;

namespace DoctorWho.Db.Repositoris
{
    public class AuthorRepository : IAuthorRepository
    {
      
            public void Create(string AuthorName)
            {
                if (AuthorName == null) throw new ArgumentNullException("Author name cannot be null!");
                DoctorWhoCoreDbContext._context.Authors.Add(new Author(AuthorName));
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            public void Update(Author Author)
            {
                if (Author == null) throw new ArgumentNullException("Author table is empty");
                DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            public void Delete(Author Author)
            {
                if (Author == null) throw new ArgumentNullException("Author table is empty");
                try
                {
                    DoctorWhoCoreDbContext._context.Authors.Remove(Author);
                    DoctorWhoCoreDbContext._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
    }
}