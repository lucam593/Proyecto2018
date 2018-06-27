using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;

namespace UIWeb.Rest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlatosWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PlatosWS.svc or PlatosWS.svc.cs at the Solution Explorer and start debugging.
    public class PlatosWS : IPlatosWS
    {
        public List<BL_Plato> listaPlatos()
        {
            ManejadorPlatos platos = new ManejadorPlatos();
            return platos.cargarPlatos();
        }

        public BL_Plato plato(short cod)
        {
            BL_Plato blPlato = new BL_Plato();
            blPlato.cargarPlato(cod);
            return blPlato;
        }
    }
}
