using System;
using System.Collections.Generic;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class Monedum
    {
        public Monedum()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int Id { get; set; }
        public string DescripcionMoneda { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
