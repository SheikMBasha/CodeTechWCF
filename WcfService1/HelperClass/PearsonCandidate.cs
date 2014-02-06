using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.HelperClass
{
    [DataContract]
    public class PearsonCandidate
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public string FirstName { get; set; }
        [DataMember(Order = 2)]
        public String LastName { get; set; }
        [DataMember(Order = 3)]
        public int ExamNature { get; set; }
        [DataMember(Order = 4)]
        public string ExamId { get; set; }
        [DataMember(Order = 5)]
        public string VoucherId { get; set; }
        [DataMember(Order = 6)]
        public string CiscoClientId { get; set; }
        [DataMember(Order = 7)]
        public string ExamStatus { get; set; }
        [DataMember(Order = 8)]
        public string Attempts { get; set; }
        [DataMember(Order = 9)]
        public DateTime ExamDate { get; set; }
        [DataMember(Order = 10)]
        public string EmailAddress { get; set; }
        [DataMember(Order = 11)]
        public string ExamEmailAddress { get; set; }
        [DataMember(Order = 12)]
        public string ExamEmailPassword { get; set; }
        [DataMember(Order = 13)]
        public string Address { get; set; }
        [DataMember(Order = 14)]
        public int Phone { get; set; }
        [DataMember(Order = 15)]
        public int InstituteId { get; set; }
        [DataMember(Order = 16)]
        public int AcademyId { get; set; }
        [DataMember(Order = 17)]
        public string ConnectionId { get; set; }
        [DataMember(Order = 18)]
        public int SiteId { get; set; }
    }
}