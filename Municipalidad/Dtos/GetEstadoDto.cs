namespace Municipalidad.Abastecimiento.WebAPI.Dtos
{
    public class GetEstadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Color { get; set; }
    }
}
