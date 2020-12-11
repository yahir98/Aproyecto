using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1998YIUL0801199901278.Models.Response
{
    public class Respuesta
    {

        public int Exito { get; set; }

        public string Mensaje { get; set; }

        public Object Data { get; set; }

        public Respuesta()
        {
            this.Exito = 0;
        }


    }
}
