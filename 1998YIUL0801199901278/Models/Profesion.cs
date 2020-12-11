using System;
using System.Collections.Generic;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class Profesion
    {
        public Profesion()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Profesion1 { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
