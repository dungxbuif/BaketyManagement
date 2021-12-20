using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class Bill
    {
        public Bill()
        {
            BilDetails = new HashSet<BilDetail>();
        }

        public int IdBill { get; set; }
        public int? IdStaff { get; set; }
        public DateTime ExportDate { get; set; }
        public double? Discount { get; set; }

        public virtual staff IdStaffNavigation { get; set; }
        public virtual ICollection<BilDetail> BilDetails { get; set; }
    }
}
