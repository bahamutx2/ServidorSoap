using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace BLL
{
    public class Gestion_Criptografia
    {
        public static string CrearHash(string texto)
        {
            string textoHash = Cryptographer.CreateHash("CifradoPasswords", texto);
            return textoHash;
        }

        public static bool CompararHash(string textoProbar, string textoHash)
        {
            bool result = Cryptographer.CompareHash("CifradoPasswords", textoProbar, textoHash);
            return result;
        }
    }
}
