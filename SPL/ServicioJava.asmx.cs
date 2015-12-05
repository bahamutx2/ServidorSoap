using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;

namespace SPL
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class ServicioJava : System.Web.Services.WebService
    {
        [WebMethod]
        public bool ValidarUsuarioJava(string username, string password)
        {
            Gestion_Usuario ubll = new Gestion_Usuario();
            return ubll.ValidarUsuarioAdmin(username, password);
        }

        
        [WebMethod]
        public string ObtenerCamarasActuales()
        {
            Gestion_Camara cbll = new Gestion_Camara();
            return cbll.ObtenerCamarasActuales();
        }

        [WebMethod]
        public string ObtenerSectoresActuales()
        {
            Gestion_Sector sbll = new Gestion_Sector();
            return sbll.ObtenerSectoresActuales();
        }

        [WebMethod]
        public string ObtenerInfoCamara(string nomnbrec)
        {
            Gestion_Camara cbll = new Gestion_Camara();
            return cbll.ObtenerInfoCamara(nomnbrec);
        }

        [WebMethod]
        public bool crearCamara(string nombreCamara, string nombreSector)
        {
            Gestion_Camara cbll = new Gestion_Camara();
            return cbll.crearCamara(nombreCamara, nombreSector);
        }

        [WebMethod]
        public bool editarCamara(string nombreCamara, string nuevonombre, string nombreSector)
        {
            Gestion_Camara cbll = new Gestion_Camara();
            return cbll.editarCamara(nombreCamara,nuevonombre, nombreSector);
        }

        [WebMethod]
        public bool eliminarCamara(string nombreCamara)
        {
            Gestion_Camara cbll = new Gestion_Camara();
            return cbll.eliminarCamara(nombreCamara);
        }


    }
}
