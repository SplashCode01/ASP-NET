using SchoolDB.Domain;
using SchoolDB.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Repository
{
    public class UnitOfWork : IDisposable
    {
        private SchoolDbContext _context;
        private Lazy<StudentRepository> _studentRepository;
        private Lazy<SubjectRepository> _subjectRepository;
        private Lazy<StudentSubjectRepository> _studentSubjectRepository;


        public UnitOfWork()
        {
            _context = new SchoolDbContext();
            Initialize();
        }

        public StudentRepository StudentRepository { get { return _studentRepository.Value; } }
        public SubjectRepository SubjectRepository { get { return _subjectRepository.Value; } }
        public StudentSubjectRepository StudentSubjectRepository { get { return _studentSubjectRepository.Value; } }

        private void Initialize()
        {
            _studentRepository = new Lazy<StudentRepository>(() => new StudentRepository(_context));
            _subjectRepository = new Lazy<SubjectRepository>(() => new SubjectRepository(_context));
            _studentSubjectRepository = new Lazy<StudentSubjectRepository>(() => new StudentSubjectRepository(_context));
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
