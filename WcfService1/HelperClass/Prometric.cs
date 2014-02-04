using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.HelperClass
{
    [DataContract]
    public class Prometric
    {
        [DataMember(Order = 0)]
        public int SiteId { get; set; }
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public string POCName { get; set; }
        [DataMember(Order = 3)]
        public int POCPhone { get; set; }
        [DataMember(Order = 4)]
        public string POCEmail { get; set; }
        [DataMember(Order = 5)]
        public string SiteAddress { get; set; }
        [DataMember(Order = 6)]
        public bool IsHired { get; set; }
        [DataMember(Order = 7)]
        public string PerExamProfit { get; set; }
        [DataMember(Order = 8)]
        public int TCAAdminId { get; set; }
        [DataMember(Order = 9)]
        public string SiteOwnerName { get; set; }
    }
}