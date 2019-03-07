using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingtonSchools.Api.Models
{
    public class School
    {
        public Guid SchoolId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
