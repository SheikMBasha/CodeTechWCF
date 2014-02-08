using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.HelperClass.Exams
{
    [DataContract]
    public class ExamTrainings
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string ExamId { get; set; }

        [DataMember(Order = 2)]
        public Nullable<System.DateTime> StartDate { get; set; }

        [DataMember(Order = 3)]
        public Nullable<System.DateTime> EndDate { get; set; }

        [DataMember(Order = 4)]
        public Nullable<int> TrainingCost { get; set; }

        [DataMember(Order = 5)]
        public Nullable<int> TotalAmountReceived { get; set; }

        [DataMember(Order = 6)]
        public Nullable<int> TrainerId { get; set; }
    }
}

/*
 Id int 11
ExamId varchar(7)
StartDate datetime
EndDate datetime
TrngCost int 11
TotalAmountRcv int 11
TrnrId int 11
 */