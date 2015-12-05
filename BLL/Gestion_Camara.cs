using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Gestion_Camara
    {

        DAO_Camara dc = new DAO_Camara();

        public bool crearCamara(string nombreCamara, string nombreSector)
        {
            return dc.crearCamara(nombreCamara, nombreSector);
        }

        public bool editarCamara(string nombreCamara, string nuevonombre, string nombreSector)
        {
            return dc.editarCamara(nombreCamara, nuevonombre, nombreSector);
        }

        public bool eliminarCamara(string nombreCamara)
        {
            return dc.eliminarCamara(nombreCamara);
        }

        public void grabarEnCamara(string nombreCamara)
        {
            dc.grabarEnCamara(nombreCamara);
        }

        public string ObtenerCamarasActuales()
        {
            DataTable dt = dc.obtenerCamarasActuales();
            string cadena = "";
            foreach (DataRow dr in dt.Rows)
            {
                cadena += dr["NombreCamara"].ToString() + "&/&";
            }
            if (cadena.Length > 0)
            {
                return cadena.Substring(0, cadena.Length - 3);
            }
            else
            {
                return "";
            }
        }

        public string ObtenerInfoCamara(string nombreCamara)
        {
            DataTable dt = dc.obtenerInfoCamara(nombreCamara);
            string cadena = dt.Rows[0]["NombreSector"].ToString();
            return cadena;
        }

        public List<string> ObtenerCamarasDisponibles()
        {
            List<string> cams = new List<string>();
            DataTable dt = dc.obtenerCamarasDisponibles();
            foreach(DataRow dr in dt.Rows){
                cams.Add(dr["NombreCamara"].ToString());
            }
            return cams;
        }

        public bool subirVideoLogico(string nombrevideo)
        {
            DAO_Usuario du = new DAO_Usuario();
            DataTable dtmod = du.ObtenerModeradores();
            foreach (DataRow dr in dtmod.Rows)
            {
                Gestion_Configuracion.EnviarMail(dr["email"].ToString(), "Nuevo video agregado", "Se ha agregado el video " + nombrevideo + " y está disponible para su revisión ");
            }
            string nombrecam = nombrevideo.Split('.')[0];
            string[] itemsfechahora = nombrevideo.Split('.')[1].Substring(0,nombrevideo.Split('.')[1].Length -4).Split('_');

            DateTime fechain = new DateTime(int.Parse(itemsfechahora[0]), int.Parse(itemsfechahora[1]), int.Parse(itemsfechahora[2]), int.Parse(itemsfechahora[3]), int.Parse(itemsfechahora[4]), 0);

            return dc.subirVideoLogico(nombrecam, nombrevideo, fechain);
        }

    }
}