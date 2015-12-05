using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    public class DAO_Usuario
    {
        public DataTable ObtenerLoginUsuario(string username)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = username;
            return db.ExecuteDataSet("ObtenerLoginUsuario", parametros).Tables[0];
        }

        public bool CambiarPassUsuario(string username, string pass)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[2];
            parametros[0] = username;
            parametros[1] = pass;
            db.ExecuteNonQuery("CambiarPassUsuario", parametros);
            return true;
        }

        public bool CrearModerador(string username, string email, string pass)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[3];
            parametros[0] = username;
            parametros[1] = email;
            parametros[2] = pass;
            db.ExecuteNonQuery("CrearAdministradorContenidos", parametros);
            return true;
        }

        public bool EliminarModerador(string username)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = username;
            db.ExecuteNonQuery("EliminarLogicoAdministradorContenidos", parametros);
            return true;
        }

        public DataTable ObtenerUsuario(string username)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = username;
            return db.ExecuteDataSet("ObtenerInformacionUsuario", parametros).Tables[0];
        }

        public DataTable ObtenerModeradores()
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            return db.ExecuteDataSet(CommandType.StoredProcedure, "ObtenerModeradores").Tables[0];
        }

       
    }
}
