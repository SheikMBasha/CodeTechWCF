using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.HelperClass
{
    [DataContract]
    public class PrometricCandidate
    {
        [DataMember(Order=0)]
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public string ExamNature { get; set; }
        [DataMember(Order = 3)]
        public string ExamId { get; set; }
        [DataMember(Order = 4)]
        public string VoucherId { get; set; }
        [DataMember(Order = 5)]
        public string CandidateId { get; set; }
        [DataMember(Order = 6)]
        public string ExamStatus { get; set; }
        [DataMember(Order = 7)]
        public string Attempts { get; set; }
        [DataMember(Order = 8)]
        public DateTime? ExamDate { get; set; }
        [DataMember(Order = 9)]
        public string EmailAddress { get; set; }
        [DataMember(Order = 10)]
        public string Address { get; set; }
        [DataMember(Order = 11)]
        public long Phone { get; set; }
        [DataMember(Order = 12)]
        public int InstituteId { get; set; }
        [DataMember(Order = 13)]
        public string ClientId { get; set; }
        [DataMember(Order = 14)]
        public bool Abroad { get; set; }
        [DataMember(Order = 15)]
        public int SiteId { get; set; }
    }
}