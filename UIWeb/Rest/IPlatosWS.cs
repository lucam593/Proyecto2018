using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;
using System.ServiceModel.Web;

namespace UIWeb.Rest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlatosWS" in both code and config file together.
    [ServiceContract]
    public interface IPlatosWS
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<BL_Plato> listaPlaots();

        [OperationContract]
        BL_Plato plato(Int16 cod);
    }
}
