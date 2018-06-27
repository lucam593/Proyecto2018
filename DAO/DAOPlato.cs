using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;


namespace DAO
{
    public class DAOPlato
    {
        public DAOPlato()
        {

        }
        public List<TO_Plato> cargarPlatos()
        {
            var ent = new ProyectoEntidades();
            var consulta = from c in ent.Platoes select c;
            var list = consulta.ToList();

            List<TO_Plato> toplatos = new List<TO_Plato>();

            foreach (var item in list)
            {
                toplatos.Add(new TO_Plato (item.Codigo_Plato, item.Nombre,item.Descripcion,Convert.ToDouble(item.Precio),item.Fotografia,item.Habilitado));
            }
            return toplatos;
        }

        public TO_Plato cargarPlato(Int16 codigo)
        {
            var ent = new ProyectoEntidades();
            var consulta = from c in ent.Platoes where c.Codigo_Plato == codigo  select c;
            var plato = consulta.FirstOrDefault();

            return new TO_Plato(plato.Codigo_Plato, plato.Nombre, plato.Descripcion, Convert.ToDouble(plato.Precio), plato.Fotografia, plato.Habilitado);
        }


    }
}
