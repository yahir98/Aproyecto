using System;
using System.Collections.Generic;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuentum>();
        }

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

        public virtual Estado CodigoEstadoNavigation { get; set; }
        public virtual Ciudad IdCiudadNavigation { get; set; }
        public virtual Profesion IdProfesionNavigation { get; set; }
        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
