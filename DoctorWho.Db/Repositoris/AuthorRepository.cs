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
    public class AuthorRepository<T> : IGenericRepository<Author> 
    {

            public Author Create(Author tValue)
            {
                if (tValue == null) throw new ArgumentNullException("Author name cannot be null!");
                DoctorWhoCoreDbContext._context.Authors.Add(new Author { AuthorName = tValue.AuthorName });
                DoctorWhoCoreDbContext._context.SaveChanges();
            return tValue;
            }
            public Author Update(Author tValue)
            {
                if (tValue == null) throw new ArgumentNullException("Author table is empty");
                DoctorWhoCoreDbContext._context.SaveChanges();
                  return (Author)tValue;
            }
            public Author Delete(Author tValue)
            {
                if (tValue == null) throw new ArgumentNullException("Author table is empty");
                try
                {
                    DoctorWhoCoreDbContext._context.Authors.Remove(tValue);
                    DoctorWhoCoreDbContext._context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            return tValue;
            }
        public List<Author> GetAllRecords()
        {
            return DoctorWhoCoreDbContext._context.Authors.ToList();
        }
        public Author GetRecordyById(Author TId) 
        {
            var author = DoctorWhoCoreDbContext._context.Authors.Find(TId.AuthorId);
            return author != null ? author : throw new NullReferenceException("No companions with this Id in the table!");

        }

    }
}