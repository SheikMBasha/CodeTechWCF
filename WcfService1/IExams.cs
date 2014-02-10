using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CodeTechnologiesWCF.HelperClass.Exams;

namespace CodeTechnologiesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IExams
    {

        [OperationContract]
        List<ExamNature> GetAllExamNature();

        [OperationContract]
        void AddExamNature(ExamNature natureObj);

        [OperationContract]
        ExamNature getExamNature(int id);

        [OperationContract]
        void UpdateExamNature(ExamNature natureObj);

        [OperationContract]
        void DeleteExamNature(int id);

        /*************************************/

        [OperationContract]
        List<ExamsType> GetAllExamTypes();

        [OperationContract]
        void AddExamType(ExamsType typObj);

        [OperationContract]
        ExamsType getExamType(int id);

        [OperationContract]
        void UpdateExamType(ExamsType typObj);

        [OperationContract]
        void DeleteExamType(int id);

        /*************************************/

        [OperationContract]
        List<ExamCodes> GetAllExamCodes();

     /*   [OperationContract]
        void AddExamCodes(ExamNature codObj);

        [OperationContract]
        ExamNature getExamCodes(int id);

        [OperationContract]
        void UpdateExamCodes(ExamNature codObj);

        [OperationContract]
        void DeleteExamCodes(int id);
      */
    }
}
