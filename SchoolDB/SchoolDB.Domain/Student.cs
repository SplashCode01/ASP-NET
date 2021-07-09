using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB.Domain
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public byte Age { get; set; }
        [Required]
        public Sex Sex { get; set; }

        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }

    public enum Sex
    {
        Female = 1,
        Male = 2
    }
}
