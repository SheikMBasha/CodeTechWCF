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
    public interface IPrometricCandidate
    {
        [OperationContract]
        List<PrometricCandidate> GetAllPrometricCandidates();

        [OperationContract]
        void BulkUploadPrometricCandidates(FileData inputexcel);
    }
}
