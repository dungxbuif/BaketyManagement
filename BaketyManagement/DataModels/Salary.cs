using BaketyManagement.DataModels;
using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp13212.Models
{
    public partial class Salary
    {
        public int IdSalary { get; set; }
        public int? IdStaff { get; set; }
        public DateTime? TimeKeeped { get; set; }
        public double? WorkingTime { get; set; }
        public double? HoursOverTime { get; set; }
        public double? SalaryOver { get; set; }
        public double? SalaryOverTime { get; set; }

        public virtual staff IdStaffNavigation { get; set; }
    }
}


