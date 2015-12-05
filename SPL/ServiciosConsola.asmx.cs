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
    /// Descripción breve de ServiciosConsola
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    public class ServiciosConsola : System.Web.Services.WebService
    {

        [WebMethod]
        public bool ValidarUsuarioConsola(string username, string password)
        {
            Gestion_Usuario ubll = new Gestion_Usuario();
            return ubll.ValidarUsuarioAdmin(username, password);
        }

        [WebMethod]
        public int[] ObtenerParametrosConfiguracion()
        {
            Gestion_Configuracion cbll = new Gestion_Configuracion();
            return cbll.obtenerParametrosConfiguracion();
        }

        [WebMethod]
        public bool ActualizarParametros(int[] parametros)
        {
            Gestion_Configuracion cbll = new Gestion_Configuracion();
            return cbll.actualizarParametros(parametros);
        }

        [WebMethod]
        public bool CrearEditarModerador(string nick, string email)
        {
            Gestion_Usuario ubll = new Gestion_Usuario();
            return ubll.CrearModerador(nick, email);
        }

        [WebMethod]
        public DataTable ObtenerInfoUsuario(string nick)
        {
            Gestion_Usuario sbll = new Gestion_Usuario();
            return sbll.ObtenerInfoUsuario(nick);
        }

        [WebMethod]
        public bool EliminarModerador(string nick)
        {
            Gestion_Usuario ubll = new Gestion_Usuario();
            return ubll.EliminarModerador(nick);
        }

        [WebMethod]
        public bool CrearEditarSector(string nombre, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            Gestion_Sector sbll = new Gestion_Sector();
            return sbll.CrearEditarSector(nombre, x1, y1, x2, y2, x3, y3, x4, y4);
        }

        [WebMethod]
        public DataTable ObtenerInfoSector(string nombre)
        {
            Gestion_Sector sbll = new Gestion_Sector();
            return sbll.ObtenerInfoSector(nombre);
        }

        [WebMethod]
        public bool EliminarSector(string nombre)
        {
            Gestion_Sector sbll = new Gestion_Sector();
            return sbll.EliminarSector(nombre);
        }

        [WebMethod]
        public bool CrearEditarCategoria(string nombre, string nombreedit)
        {
            Gestion_Categorias cbll = new Gestion_Categorias();
            return cbll.CrearEditarCategoria(nombre, nombreedit);
        }

        [WebMethod]
        public DataTable ObtenerInfoCategoria(string nombre)
        {
            Gestion_Categorias cbll = new Gestion_Categorias();
            return cbll.ObtenerInfoCategoria(nombre);
        }

        [WebMethod]
        public bool EliminarCategoria(string nombre)
        {
            Gestion_Categorias cbll = new Gestion_Categorias();
            return cbll.EliminarCategoria(nombre);
        }

        [WebMethod]
        public string GenerarHash(string text)
        {
            return Gestion_Criptografia.CrearHash(text);
        }

        [WebMethod]
        public void EnviarEmail(string to, string sub, string body)
        {
            Gestion_Configuracion.EnviarMail(to, sub, body);
        }
    }
}