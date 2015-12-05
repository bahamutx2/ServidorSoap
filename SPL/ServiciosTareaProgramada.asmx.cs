using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;

namespace SPL
{
    /// <summary>
    /// Summary description for ServiciosTareaProgramada
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiciosTareaProgramada : System.Web.Services.WebService
    {

        [WebMethod]
        public int obtenerTiempoBackup()
        {
            Gestion_Configuracion gc = new Gestion_Configuracion();
            return gc.obtenerTiempoBackup();
        }
    }
}
