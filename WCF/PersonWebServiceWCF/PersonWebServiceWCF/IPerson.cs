using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebServiceWCF
{
    [ServiceContract]
    interface IPerson
    {
        [OperationContract]
        string GetAll();

        [OperationContract]
        string GetById(string id);

        [OperationContract]
        void Create(string id, string firstname, string lastname);

        [OperationContract]
        void Update(string id, string firstname, string lastname);

        [OperationContract]
        void Delete(string id);

        [OperationContract]
        string SearchByLastName(string lastname);


    }
}
