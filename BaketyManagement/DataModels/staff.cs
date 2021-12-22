using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class staff
    {
        public staff()
        {
            Bills = new HashSet<Bill>();
            Salaries = new HashSet<Salary>();
        }

        public int IdStaff { get; set; }
        public string NameStaff { get; set; }
        public bool? Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
