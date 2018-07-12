using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;

namespace DAO
{
    public class DAO_Estado
    {
        ProyectoEntidades entidades = new ProyectoEntidades();

        public List<TO_Estado> cargarEstados()
        {
            var ent = new ProyectoEntidades();
            var consulta = from c in ent.Estadoes select c;
            var list = consulta.ToList();

            List<TO_Estado> toestados = new List<TO_Estado>();

            foreach (var item in list)
            {
                toestados.Add(new TO_Estado((short)item.LimiteMinutos,item.NombreEstado, (short)item.Indice));
            }
            return toestados;
        }

        public void modificarEstado(string nombre, short tiempo)
        {
            ProyectoEntidades entidades = new ProyectoEntidades();
            Estado estado = (from esta in entidades.Estadoes where esta.NombreEstado == nombre select esta).Single();
            estado.LimiteMinutos = tiempo;
            entidades.SaveChanges();
        }
    }
}
