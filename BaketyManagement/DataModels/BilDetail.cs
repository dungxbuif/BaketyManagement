using System;
using System.Collections.Generic;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class BilDetail
    {
        public int IdBill { get; set; }
        public int IdCake { get; set; }
        public int? AmountOrder { get; set; }

        public virtual Bill IdBillNavigation { get; set; }
        public virtual Cake IdCakeNavigation { get; set; }
    }
}
