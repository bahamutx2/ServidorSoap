using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    public class DAO_Sector
    {

        public bool CrearEditarSector(string nombre, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[9];
            parametros[0] = nombre;
            parametros[1] = x1;
            parametros[2] = y1;
            parametros[3] = x2;
            parametros[4] = y2;
            parametros[5] = x3;
            parametros[6] = y3;
            parametros[7] = x4;
            parametros[8] = y4;
            db.ExecuteNonQuery("CrearEditarSector", parametros);
            return true;
        }

        public bool EliminarSector(string nombre)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = nombre;
            db.ExecuteNonQuery("EliminarSector", parametros);
            return true;
        }

        public DataTable ObtenerSector(string nombre)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = nombre;
            return db.ExecuteDataSet("ObtenerInformacionSector", parametros).Tables[0];
        }

        public DataTable obtenerSectoresActuales()
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            return db.ExecuteDataSet(CommandType.StoredProcedure, "ObtenerSectoresActuales").Tables[0];
        }

    }
}
