namespace Municipalidad.Abastecimiento.WebAPI.Dtos
{
    public class GetOrdenDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; } = null!;
        public int AreaId { get; set; }
        public string AreaNombre { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; } = null!;
        public string? EstadoColor { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? Observaciones { get; set; }
    }
}
