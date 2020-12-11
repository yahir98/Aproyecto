using System;
using System.Collections.Generic;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class Pai
    {
        public Pai()
        {
            Departamentos = new HashSet<Departamento>();
        }

        public int Id { get; set; }
        public string Decripcion { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
