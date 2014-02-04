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
    public interface IPrometric
    {
        [OperationContract]
        List<Prometric> GetAllPrometrics();

        [OperationContract]
        void AddPrometric(Prometric pObj);

        [OperationContract]
        Prometric getPrometric(int id);

        [OperationContract]
        void UpdatePrometric(Prometric pObj);

        [OperationContract]
        void DeletePrometric(int id);
    }
}
