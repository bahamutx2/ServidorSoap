using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Gestion_Sector
    {

        DAO_Sector ds = new DAO_Sector();

        public bool CrearEditarSector(string nombre, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            return ds.CrearEditarSector(nombre, x1, y1, x2, y2, x3, y3, x4, y4);
        }

        public bool EliminarSector(string nombre)
        {
            return ds.EliminarSector(nombre);
        }

        public DataTable ObtenerSectores()
        {
            return ds.obtenerSectoresActuales();
        }

        public DataTable ObtenerInfoSector(string nombre)
        {
            return ds.ObtenerSector(nombre);
        }

        public string ObtenerSectoresActuales()
        {
            DataTable dt = ds.obtenerSectoresActuales();
            string cadena = "";
            foreach (DataRow dr in dt.Rows)
            {
                cadena += dr["nombreSector"].ToString() + "&/&";
            }
            if (cadena.Length <= 0)
            {
                return "";
            }
            else
            {
                return cadena.Substring(0, cadena.Length - 3);
            }
        }

    }
}
