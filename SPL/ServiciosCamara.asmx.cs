using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using BLL;

namespace SPL
{
    /// <summary>
    /// Descripción breve de ServiciosCamara
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiciosCamara : System.Web.Services.WebService
    {
        [WebMethod]
        public bool ValidarUsuarioCSharp(string username, string password)
        {
            Gestion_Usuario ubll = new Gestion_Usuario();
            return ubll.ValidarUsuarioAdmin(username, password);
        }

        [WebMethod]
        public List<string> ObtenerCamarasDisponibles()
        {
            Gestion_Camara cbll = new Gestion_Camara();
            return cbll.ObtenerCamarasDisponibles();
        }

        [WebMethod]
        public int obtenerTiempoVideo()
        {
            Gestion_Configuracion cbll = new Gestion_Configuracion();
            return cbll.obtenerTiempoVideo();
        }

        [WebMethod]
        public void grabarEnCamara(string nombrecamara)
        {
            Gestion_Camara gc = new Gestion_Camara();
            gc.grabarEnCamara(nombrecamara);
        }

        [WebMethod]
        public void subirVideoLogico(string nombrearchivo)
        {
            Gestion_Camara gc = new Gestion_Camara();
            gc.subirVideoLogico(nombrearchivo);
        }

        [WebMethod]
        public DateTime obtenerFechaServidor()
        {
            return DateTime.Now;
        }

    }
}
