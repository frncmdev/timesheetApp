using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public string TeacherId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string Salt { get; set; } = null!;

        public virtual ICollection<Class> Classes { get; set; }
    }
}
