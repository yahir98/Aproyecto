using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1998YIUL0801199901278.Models.Request
{
    public class CuentaRequest
    {

        public int Id { get; set; }
        public int CodigoCliente { get; set; }
        public int TipoCuenta { get; set; }
        public int TipoMondea { get; set; }
        public int CodigoEstado { get; set; }
        public decimal Saldo { get; set; }
    }
}
