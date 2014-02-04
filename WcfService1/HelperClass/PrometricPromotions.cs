using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.HelperClass
{
    [DataContract]
    public class PrometricPromotions
    {
        [DataMember(Order = 0)]
        public int id { get; set; }
        [DataMember(Order = 1)]
        public Nullable<int> SiteId { get; set; }
        [DataMember(Order = 2)]
        public System.DateTime DateFrom { get; set; }
        [DataMember(Order = 3)]
        public System.DateTime DateTo { get; set; }
        [DataMember(Order = 4)]
        public Nullable<int> MarginGain { get; set; }
        [DataMember(Order = 5)]
        public Nullable<int> MarginMiss { get; set; }
    }
}