using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Gestion_Categorias
    {
        DAO_Categorias dc = new DAO_Categorias();

        public bool CrearEditarCategoria(string nombre, string nombreedit)
        {
            return dc.CrearEditarCategoria(nombre, nombreedit);
        }

        public bool EliminarCategoria(string nombre)
        {
            return dc.EliminarCategoria(nombre);
        }

        public DataTable ObtenerInfoCategoria(string nombre)
        {
            return dc.ObtenerInfoCategoria(nombre);
        }

        public List<string> ObtenerCategorias()
        {
            List<string> listac = new List<string>();
            DataTable dt = dc.ObtenerCategorias();
            foreach (DataRow dr in dt.Rows)
            {
                listac.Add(dr["nombreCategoria"].ToString());
            }
            return listac;
        }
    }
}
