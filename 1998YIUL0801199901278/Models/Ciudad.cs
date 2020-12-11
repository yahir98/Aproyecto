using System;
using System.Collections.Generic;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public int? CodigoDepartamento { get; set; }
        public string Ciudad1 { get; set; }

        public virtual Departamento CodigoDepartamentoNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
