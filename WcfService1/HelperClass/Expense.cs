using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.HelperClass
{
    [DataContract]
    public class Expense
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public string ExpenseType { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> AmountPaid { get; set; }
        [DataMember(Order = 3)]
        public Nullable<System.DateTime> Date { get; set; }
        [DataMember(Order = 4)]
        public string PaymentChannel { get; set; }
        [DataMember(Order = 5)]
        public Nullable<int> SiteId { get; set; }
    }
}