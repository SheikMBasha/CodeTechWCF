using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfService1.HelperClass;

namespace WcfService1
{
    [ServiceContract]
    public interface IPearsonCandidate
    {
        [OperationContract]
        List<PearsonCandidate> GetAllPearsonCandidates();

        [OperationContract]
        void BulkUploadPearsonCandidates(FileData inputexcel);

        [OperationContract]
        void AddPearsonCandidate(PearsonCandidate pcObj);

        [OperationContract]
        PearsonCandidate getPearsonCandidate(int id);

        [OperationContract]
        void UpdatePearsonCandidate(PearsonCandidate pcObj);

        [OperationContract]
        void DeletePearsonCandidate(int id);
    }
}
