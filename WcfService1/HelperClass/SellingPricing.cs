using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.HelperClass
{
    [DataContract]
    public class SellingPricing
    {
        [DataMember(Order=0)]
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public int InstituteId { get; set; }
        [DataMember(Order = 2)]
        public string ClientId { get; set; }
        [DataMember(Order = 3)]
        public string VoucherType { get; set; }
        [DataMember(Order = 4)]
        public string VoucherNature { get; set; }
        [DataMember(Order = 5)]
        public decimal PriceWithVoucher { get; set; }
        [DataMember(Order = 6)]
        public decimal PriceWithoutVoucher { get; set; }
        [DataMember(Order = 7)]
        public decimal PriceWithTraining { get; set; }
        [DataMember(Order = 8)]
        public decimal AbroadPrice { get; set; }
        [DataMember(Order = 9)]
        public DateTime PriceDate { get; set; }
    }
}