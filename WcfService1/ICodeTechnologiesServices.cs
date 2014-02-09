using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTechnologiesWCF;
using System.ServiceModel;
using WcfService1.HelperClass.Exams;
using WcfService1.HelperClass;


namespace WcfService1
{
    [ServiceContract]
    public interface ICodeTechnologiesServices : IExams, IAcademy, IPrometricCandidate, IPrometric, IPrometricPromotions,IInstitute, IExpense, IPearsonCandidate, ISellingPricing
    {
    }
}
