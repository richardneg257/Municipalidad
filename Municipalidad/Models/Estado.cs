using System;
using System.Collections.Generic;

namespace Municipalidad.Abastecimiento.WebAPI.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Ordenes = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Color { get; set; }

        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
