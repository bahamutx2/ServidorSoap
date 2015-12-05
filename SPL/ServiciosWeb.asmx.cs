using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using System.Data;

namespace SPL
{
    /// <summary>
    /// Descripción breve de ServiciosWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiciosWeb : System.Web.Services.WebService
    {

        [WebMethod]
        public bool IniciarSesion(string u, string p)
        {
            Gestion_Usuario gu = new Gestion_Usuario();
            return gu.ValidarUsuarioModerador(u, p);
        }

        [WebMethod]
        public DataTable ObtenerSectores()
        {
            Gestion_Sector gu = new Gestion_Sector();
            return gu.ObtenerSectores();
        }

        [WebMethod]
        public DataTable ObtenerDenuncias()
        {
            Gestion_Denuncia gu = new Gestion_Denuncia();
            return gu.ObtenerTodasDenuncias();
        }

        [WebMethod]
        public bool bloquearDenuncia(int id)
        {
            Gestion_Denuncia gu = new Gestion_Denuncia();
            return gu.bloquerdenuncia(id);
        }

        [WebMethod]
        public bool bloquearVideo(int id)
        {
            Gestion_Denuncia gu = new Gestion_Denuncia();
            return gu.bloquervideo(id);
        }

        [WebMethod]
        public bool cambiarContrasena(string usern, string pactual, string pn1, string pn2)
        {
            Gestion_Usuario gu = new Gestion_Usuario();
            return gu.cambiarContrasena(usern, pactual, pn1, pn2);
        }

        [WebMethod]
        public DataTable ObtenerReporteDenuncia()
        {
            Gestion_Estadisticas gu = new Gestion_Estadisticas();
            return gu.reporteDenuncias();
        }

        [WebMethod]
        public DataTable ObtenerReporteVideos()
        {
            Gestion_Estadisticas gu = new Gestion_Estadisticas();
            return gu.reporteVideos();
        }

    }
}
