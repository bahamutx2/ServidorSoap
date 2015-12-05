using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    public class DAO_Camara
    {

        public bool crearCamara(string nombreCamara, string nombreSector)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[2];
            parametros[0] = nombreCamara;
            parametros[1] = nombreSector;
            db.ExecuteNonQuery("CrearCamara", parametros);
            return true;
        }

        public bool editarCamara(string nombreCamara, string nuevonombre, string nombreSector)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[3];
            parametros[0] = nombreCamara;
            parametros[1] = nuevonombre;
            parametros[2] = nombreSector;
            db.ExecuteNonQuery("EditarCamara", parametros);
            return true;
        }

        public bool eliminarCamara(string nombreCamara)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = nombreCamara;
            db.ExecuteNonQuery("EliminarCamara", parametros);
            return true;
        }

        public void grabarEnCamara(string nombreCamara)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = nombreCamara;
            db.ExecuteNonQuery("GrabarEnCamara", parametros);
        }

        public DataTable obtenerCamarasActuales()
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            return db.ExecuteDataSet(CommandType.StoredProcedure, "ObtenerCamarasActuales").Tables[0];
        }

        public DataTable obtenerCamarasDisponibles()
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            return db.ExecuteDataSet(CommandType.StoredProcedure, "obtenerCamarasDisponibles").Tables[0];
        }

        public DataTable obtenerInfoCamara(string nombreCamara)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[1];
            parametros[0] = nombreCamara;
            return db.ExecuteDataSet("ObtenerInformacionCamara", parametros).Tables[0];
        }

        public bool subirVideoLogico(string nombreCamara, string nombrevideo, DateTime fechain)
        {
            Database db = DatabaseFactory.CreateDatabase("CiudadContraDelincuencia");
            object[] parametros = new object[3];
            parametros[0] = nombreCamara;
            parametros[1] = nombrevideo;
            parametros[2] = fechain;
            db.ExecuteNonQuery("SubirVideo", parametros);
            return true;
        }

    }
}
