using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;

namespace WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Platos : IPlatos
    {
        public List<BL_Plato> listaPlaots()
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
