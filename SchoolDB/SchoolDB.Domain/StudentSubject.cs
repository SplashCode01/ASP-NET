using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Domain
{
    public class StudentSubject
    {
        [Key, Column(Order = 0)]
        public int StudentID { get; set; }
        [Key, Column(Order = 1)]
        public int SubjectID { get; set; }

        public int? Point { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
