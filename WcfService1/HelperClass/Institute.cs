using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.HelperClass
{
    [DataContract]
    public class Institute
    {
        [DataMember]
        public int Id { get; set; }        

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public string POCName { get; set; }

        [DataMember(Order = 3)]
        public long Phone { get; set; }

        [DataMember(Order = 4)]
        public string Email { get; set; }

        [DataMember(Order = 5)]
        public string Address { get; set; }

        [DataMember(Order = 6)]
        public Nullable<int> CreditAllowed { get; set; }

        [DataMember(Order = 7)]
        public Nullable<int> CreditRemaining { get; set; }
    }
}