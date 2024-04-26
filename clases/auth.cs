using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MECANOGRAFIA.clases
{
    internal class auth
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
        clases.helpers h = new clases.helpers();
>>>>>>> Agregar archivos de proyecto.
=======
>>>>>>> actualizacion

        public string MakeHash(string password)
        {
            string hash = "";
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] inputbytes = (new UnicodeEncoding()).GetBytes(password);
            byte[] result = sha512.ComputeHash(inputbytes);
            hash = Convert.ToBase64String(result);
            return hash;
        }
    }
}
