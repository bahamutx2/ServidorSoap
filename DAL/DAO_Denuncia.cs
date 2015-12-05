using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    public class DAO_Denuncia
    {
        public DataTable CrearDenunciaFoto(double lat, double longi, string nombreCat)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[3];
            parametros[0] = lat;
            parametros[1] = longi;
            parametros[2] = nombreCat;
            return db.ExecuteDataSet("CrearDenunciaPorFoto", parametros).Tables[0];
        }

        public bool BloquearDenunica(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = id;
            db.ExecuteNonQuery("BloquearDenunica", parametros);
            return true;
        }

        public bool BloquearVideo(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = id;
            db.ExecuteNonQuery("BloquearVideo", parametros);
            return true;
        }

        public DataTable ObtenerTodasDenuncias()
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            return db.ExecuteDataSet(CommandType.StoredProcedure, "ObtenerListadoD").Tables[0];
        }
    }
}
