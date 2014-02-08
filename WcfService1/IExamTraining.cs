using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfService1.HelperClass;
using WcfService1.HelperClass.Exams;

namespace WcfService1
{
    [ServiceContract]
    interface IExamTraining
    {
        [OperationContract]
        List<ExamTrainings> GetAllExamTrainings();

        [OperationContract]
        void AddExamTraining(ExamTrainings trngObj);

        [OperationContract]
        ExamTrainings getExamTraining(int id);

        [OperationContract]
        void UpdateExamTraining(ExamTrainings trngObj);

        [OperationContract]
        void DeleteExamTraining(int id);
    }
}
