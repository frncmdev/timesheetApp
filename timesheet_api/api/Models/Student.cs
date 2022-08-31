using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Student
    {
        public Student()
        {
            Timesheets = new HashSet<Timesheet>();
            Classes = new HashSet<Class>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Timesheet> Timesheets { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
