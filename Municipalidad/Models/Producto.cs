using System;
using System.Collections.Generic;

namespace Municipalidad.Abastecimiento.WebAPI.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Ordenes = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string? Photo { get; set; }

        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
