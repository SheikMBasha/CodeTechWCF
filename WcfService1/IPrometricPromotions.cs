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
    public interface IPrometricPromotions
    {
        [OperationContract]
        List<PrometricPromotions> getAllPrometricPromotions();

        [OperationContract]
        List<PrometricPromotions> getPrometricPromotionWithSiteId(int? id);

        [OperationContract]
        void AddPrometricPromotion(PrometricPromotions ppObj);

        [OperationContract]
        PrometricPromotions getPrometricPromotion(int id);

        [OperationContract]
        void UpdatePrometricPromotion(PrometricPromotions ppObj);

        [OperationContract]
        void DeletePrometricPromotion(int id);
    }
}
