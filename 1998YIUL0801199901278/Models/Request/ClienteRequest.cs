using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1998YIUL0801199901278.Models.Request
{
    public class ClienteRequest
    {

        public int Id { get; set; }
        public string PrimerN { get; set; }
        public string SegundoN { get; set; }
        public string PrimerA { get; set; }
        public string SegundoA { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Identidad { get; set; }
        public string Genero { get; set; }
        public int id_ciudad { get; set; }
        public int IdProfesion { get; set; }
        public int CodigoEstado { get; set; }

    }
}
