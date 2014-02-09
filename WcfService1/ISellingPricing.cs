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
    public interface ISellingPricing
    {
        [OperationContract]
        List<SellingPricing> GetAllSellingPrices();

        [OperationContract]
        void AddNewPricing(SellingPricing pricing);

        [OperationContract]
        SellingPricing GetPricing(int id);

        [OperationContract]
        void UpdatePricing(SellingPricing pricing);

        [OperationContract]
        void DeletePricing(int id);
    }
}
