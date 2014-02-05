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
    public interface IInstitute
    {
        [OperationContract]
        List<Institute> GetAllInstitutes();

        [OperationContract]
        void AddInstitute(Institute instiObj);

        [OperationContract]
        Institute getInstitute(int id);

        [OperationContract]
        void UpdateInstitute(Institute instiObj);

        [OperationContract]
        void DeleteInstitute(int id);
    }
}
