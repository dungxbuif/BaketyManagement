using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Salary
    {
        public int IdSalary { get; set; }
        public int? IdStaff { get; set; }
        public double? SalaryDate { get; set; }
        public DateTime? TimeKeeped { get; set; }
        public DateTime? SalaryTime { get; set; }
        public double? WorkDay { get; set; }
        public double? HoursOverTime { get; set; }
        public double? Rewards { get; set; }
        public double? SalaryOverTime { get; set; }

        public virtual staff IdStaffNavigation { get; set; }
    }
}
