using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    public class DAO_Categorias
    {
        public bool CrearEditarCategoria(string nombre, string nombreedit)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[2];
            parametros[0] = nombre;
            parametros[1] = nombreedit;
            db.ExecuteNonQuery("CrearEditarCategoria", parametros);
            return true;
        }

        public bool EliminarCategoria(string nombre)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = nombre;
            db.ExecuteNonQuery("EliminarCategoria", parametros);
            return true;
        }

        public DataTable ObtenerInfoCategoria(string nombre)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = nombre;
            return db.ExecuteDataSet("ObtenerInformacionCategoria", parametros).Tables[0];
        }

        public DataTable ObtenerCategorias()
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            return db.ExecuteDataSet(CommandType.StoredProcedure, "ObtenerCategorias").Tables[0];
        }
    }
}
