using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CodeTechnologiesWCF.HelperClass.Exams
{
    [DataContract]
    public class ExamsType
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string ExamType { get; set; }
    }
}