using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BL;

namespace UIWeb.WSCLIENTE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWS_CLIENTE" in both code and config file together.
    [ServiceContract]
    public interface IWS_CLIENTE
    {
        [OperationContract]
        [WebGet(RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json)]
        BL_Cliente cargarCliente(String nombreUsuario, String password);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool registrarCliente(String nombreUsuario, String contrasenha, String rol, String direccion, String nombreCompleto, String correo, Boolean habilitado);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool modificarDireccionCliente(String nombreUsuario, String direccion);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<BL_Plato> listaPlatos();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BL_Plato platoxCod(int cod);
    }
}
