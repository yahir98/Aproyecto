using System;
using System.Collections.Generic;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Ciudads = new HashSet<Ciudad>();
        }

        public int Id { get; set; }
        public int CodigoPais { get; set; }
        public string Departamento1 { get; set; }

        public virtual Pai CodigoPaisNavigation { get; set; }
        public virtual ICollection<Ciudad> Ciudads { get; set; }
    }
}
