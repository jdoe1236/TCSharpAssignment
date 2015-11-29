using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MVC_NCDAssignment
{
    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        bool Search(string userEmail, string name, byte? minAge, byte? maxAge, bool canBeFemale, bool canBeMale, short? minHeight, short? maxHeight, short? minWeight, short? maxWeight, string nationality);
    }
}