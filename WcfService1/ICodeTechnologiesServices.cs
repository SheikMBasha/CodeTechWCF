using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTechnologiesWCF;
using System.ServiceModel;

namespace WcfService1
{
    [ServiceContract]
    public interface ICodeTechnologiesServices : IExams, IAcademy, IPrometricCandidate
    {
    }
}
