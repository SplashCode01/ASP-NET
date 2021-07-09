using SchoolDB.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Repository.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IDisposable
    {

        public StudentRepository(SchoolDbContext context) : base(context)
        {
        }

        

        //public Dictionary<Subject, Grade?> GetAllGrades(int studentID)
        //{
        //    var result = _context.StudentSubjects.Where(q => q.StudentID == studentID).ToDictionary(q => q.Subject, q => q.Grade);
        //    return result;
        //}

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
