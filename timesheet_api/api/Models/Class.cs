using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public string ClassId { get; set; } = null!;
        public string ClassName { get; set; } = null!;
        public string ClassDescription { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
