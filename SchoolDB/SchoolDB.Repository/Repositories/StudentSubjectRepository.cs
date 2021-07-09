using SchoolDB.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Repository.Repositories
{
    public class StudentSubjectRepository : GenericRepository<StudentSubject>, IDisposable
    {
        public StudentSubjectRepository(SchoolDbContext context) : base(context)
        {
        }

        public IEnumerable<StudentSubject> GetStudentSubjects()
        {
            return _context.StudentSubjects.ToList();
        }

        public IEnumerable<StudentSubject> GetStudentPoints(int studentID)
        {
            var result = Get(q => q.StudentID == studentID).ToList();
            return result;
        }

        public IEnumerable<StudentSubject> GetSubjectPoints(string subjectName)
        {
            var result = Get(q => q.Subject.SubjectName == subjectName).ToList();
            return result;
        }

        public StudentSubject GetStudentSubjectByID(int studentID, int subjectID)
        {
            return _context.StudentSubjects.Find(studentID, subjectID);
        }

        public void InsertStudentSubject(StudentSubject studentSubject)
        {
            _context.StudentSubjects.Add(studentSubject);
        }

        public void DeleteStudentSubject(int studentID, int subjectID)
        {
            StudentSubject studentSubject = _context.StudentSubjects.Find(studentID, subjectID);
            _context.StudentSubjects.Remove(studentSubject);
        }

        public void UpdateStudentSubject(StudentSubject studentSubject)
        {
            _context.Entry(studentSubject).State = EntityState.Modified;
        }

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
