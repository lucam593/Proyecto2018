using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using BL;

namespace UIWeb.REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWSPlatos" in both code and config file together.
    [ServiceContract]
    
    public interface IWSPlatos
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<BL_Plato> listaPlatos();

        [OperationContract]
        BL_Plato platoxCod(int cod);
    }
}
