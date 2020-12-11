using System;
using System.Collections.Generic;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class TipoCuentum
    {
        public TipoCuentum()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public int Id { get; set; }
        public string DescripcionCuenta { get; set; }

        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
