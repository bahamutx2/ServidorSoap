using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using System.IO;
using System.Drawing;

namespace SPL
{
    /// <summary>
    /// Descripción breve de ServiciosMovil
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiciosMovil : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> ObtenerCategorias()
        {
            Gestion_Categorias gc = new Gestion_Categorias();
            return gc.ObtenerCategorias();
        }

        [WebMethod]
        public string CrearDenunciaPorFoto(string lat, string longi, string nombreCat, string imgb64)
        {
            double lati = Double.Parse(lat.Replace(".", ","));
            double l = Double.Parse(longi.Replace(".", ","));
            Gestion_Denuncia gc = new Gestion_Denuncia();
            string nombreArchivo = gc.CrearDenunciaPorFoto(lati, l, nombreCat, imgb64);
            byte[] imageBytes = Convert.FromBase64String(imgb64);
            string ruta = Server.MapPath("~/");
            var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            image.Save(ruta + "archivos/" + nombreArchivo);
            return "Su denuncia ha sido registrada";
        }


    }
}
