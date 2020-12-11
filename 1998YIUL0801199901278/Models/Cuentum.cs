using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class Cuentum
    {
      
        public int Id { get; set; }
        public int CodigoCliente { get; set; }
        public int TipoCuenta { get; set; }
        public int TipoMondea { get; set; }
        public int CodigoEstado { get; set; }
        public decimal Saldo { get; set; }

        public virtual Cliente CodigoClienteNavigation { get; set; }
        public virtual TipoCuentum TipoCuentaNavigation { get; set; }
        public virtual Monedum TipoMondeaNavigation { get; set; }
    }
}
