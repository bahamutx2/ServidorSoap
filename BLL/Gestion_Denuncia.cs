using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.IO;

namespace BLL
{
    public class Gestion_Denuncia
    {
        public string CrearDenunciaPorFoto(double lat, double longi, string nombreCat, string imgb64)
        {
            DAO_Denuncia dc = new DAO_Denuncia();
            DataTable dt = dc.CrearDenunciaFoto(lat, longi, nombreCat);
            return dt.Rows[0]["nombreAr"].ToString();
        }

        public DataTable ObtenerTodasDenuncias()
        {
            DAO_Denuncia dd = new DAO_Denuncia();
            DataTable dt = dd.ObtenerTodasDenuncias();
            return dt;
        }

        public bool bloquerdenuncia(int id)
        {
            DAO_Denuncia dd = new DAO_Denuncia();
            return dd.BloquearDenunica(id);
        }

        public bool bloquervideo(int id)
        {
            DAO_Denuncia dd = new DAO_Denuncia();
            return dd.BloquearVideo(id);
        }
    }
}
