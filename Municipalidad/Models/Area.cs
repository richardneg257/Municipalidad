using System;
using System.Collections.Generic;

namespace Municipalidad.Abastecimiento.WebAPI.Models
{
    public partial class Area
    {
        public Area()
        {
            Ordenes = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Encargado { get; set; } = null!;

        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
