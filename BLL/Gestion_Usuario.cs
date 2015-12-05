using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using DAL;

namespace BLL
{
    public class Gestion_Usuario
    {
        DAO_Usuario duser = new DAO_Usuario();
       
        public bool ValidarUsuarioAdmin(string username, string pass)
        {
            DataTable login = duser.ObtenerLoginUsuario(username);
            if (login.Rows.Count > 0)
            {
                bool permiso = Boolean.Parse(login.Rows[0]["isSystemAdmin"].ToString());
                if (permiso)
                {
                    if (Gestion_Criptografia.CompararHash(pass, login.Rows[0]["password"].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool ValidarUsuarioModerador(string username, string pass)
        {
            DataTable login = duser.ObtenerLoginUsuario(username);
            if (login.Rows.Count > 0)
            {
                bool permiso = Boolean.Parse(login.Rows[0]["isContentAdmin"].ToString());
                if (permiso)
                {
                    if (Gestion_Criptografia.CompararHash(pass, login.Rows[0]["password"].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CrearModerador(string username, string email)
        {
            return duser.CrearModerador(username, email, Gestion_Criptografia.CrearHash(ConfigurationManager.AppSettings["pwdDefault"]));
        }

        public bool cambiarContrasena(string usern, string pactual, string pn1, string pn2)
        {
            if (pn1 != pn2)
            {
                return false;
            }
            if (!ValidarUsuarioModerador(usern, pactual))
            {
                return false;
            }
            else
            {
                return duser.CambiarPassUsuario(usern, Gestion_Criptografia.CrearHash(pn1));
            }
        }

        public bool EliminarModerador(string username)
        {
            return duser.EliminarModerador(username);
        }

        public DataTable ObtenerInfoUsuario(string username)
        {
            return duser.ObtenerUsuario(username);
        }

    }
}
