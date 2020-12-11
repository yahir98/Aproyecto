using System;
using System.Collections.Generic;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
