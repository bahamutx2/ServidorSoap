using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Gestion_Estadisticas
    {
        DAO_Reporte dr = new DAO_Reporte();

        public DataTable reporteVideos()
        {
            return dr.getReporteVideos();
        }

        public DataTable reporteDenuncias()
        {
            return dr.getReporteDenuncias();
        }
    }
}
