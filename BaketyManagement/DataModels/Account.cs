using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Account
    {
        public string UserName { get; set; }
        public int? IdStaff { get; set; }
        public string Pass { get; set; }
        public bool? TypeAccount { get; set; }

        public virtual staff IdStaffNavigation { get; set; }
    }
}
