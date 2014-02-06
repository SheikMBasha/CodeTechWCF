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
    public interface IExpense
    {
        [OperationContract]
        List<Expense> getAllExpenses();

        [OperationContract]
        Expense getExpense(int id);

        [OperationContract]
        void AddExpense(Expense expObj);

        [OperationContract]
        void UpdateExpense(Expense expObj);

        [OperationContract]
        void DeleteExpense(int id);

    }
}
