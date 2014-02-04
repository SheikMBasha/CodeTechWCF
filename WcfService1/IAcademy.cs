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
    public interface IAcademy
    {
        [OperationContract]
        List<AcademyModel> GetAllAcademies();

        [OperationContract]
        void AdddAcademy(AcademyModel academyObj);

        [OperationContract]
        AcademyModel getAcademy(int id);

        [OperationContract]
        void UpdateAcademy(AcademyModel academyObj);

        [OperationContract]
        void DeleteAcademy(int id);
    }
}
