using System;
using System.Collections.Generic;

namespace Municipalidad.Abastecimiento.WebAPI.Models
{
    public partial class Orden
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int AreaSolicitanteId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? Observaciones { get; set; }

        public virtual Area AreaSolicitante { get; set; } = null!;
        public virtual Estado Estado { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
    }
}
